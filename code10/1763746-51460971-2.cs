    [Route("api/[controller]")]
    public class EntitiesController : Controller {
        private readonly ApplicationDbContext dbContext;
        public EntitiesController(ApplicationDbContext _dbContext) {
            this.dbContext = _dbContext;
        }
        //GET api/entities
        [HttpGet]
        public IActionResult GetEntities() {
            var result = dbContext.Entities.ToListAsync();
            return Ok(result);
        }
    }
