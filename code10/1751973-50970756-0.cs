    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        [HttpGet]
        [AutoQueryable]
        public IQueryable<Person> Get([FromServices] myDbContext dbContext)
        {
            return dbContext.Person.Select(p => new Person() { 
               --other props go here--, 
               prescDoc = p.prescDoc.Id == 0 ? null: p.prescDoc 
               } 
               );
        }
    }
