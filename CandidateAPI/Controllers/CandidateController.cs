using CandidateAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CandidateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly AppDbContext db;

        public CandidateController(AppDbContext context)
        {
           db = context;
        }
        // GET: api/<CandidateController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidateModel>>> GetAllCndidates()
        {
            return await db.Candidates.ToListAsync();
        }


        // GET api/<CandidateController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateModel>> GetCandidate(int id)
        {
            var candidate = await db.Candidates.FindAsync(id);
            if(candidate !=null)
            {
                return candidate;
            }
            return NotFound();
        }

        // POST api/<CandidateController>
        [HttpPost]
        public async Task<ActionResult<CandidateModel>> PostCandidate(CandidateModel model)
        {
            db.Candidates.Add(model);
            await db.SaveChangesAsync();
            return CreatedAtAction("GetCandidate", new { Id = model.Id, model });

        }

       
    }
}
