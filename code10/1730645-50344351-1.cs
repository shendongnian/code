    using DL.SO.ModelState.Dto.Users;
    using Microsoft.AspNetCore.Mvc;
    namespace DL.SO.ModelState.Controllers
    {
        [Route("api/[controller]")]
        public class UsersController : ControllerBase
        {
            [HttpGet("{id}")]
            public IActionResult GetById(string id)
            {
                // Just testing 
                return Ok(id);
            }
            [HttpPost]
            public IActionResult Post(AccountModel model)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                // Just testing so I pass in null
                return CreatedAtAction(nameof(GetById), 
                     new { id = model.AccountNumber }, null);
            }
        }
    }
