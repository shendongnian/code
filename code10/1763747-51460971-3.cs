    [Route("api/[controller]")]
    public class EntitiesController : Controller {
        private readonly ApplicationDbContext dbContext;
        public EntitiesController(ApplicationDbContext _dbContext) {
            this.dbContext = _dbContext;
        }
        //GET api/entities
        [HttpGet]
        public Task<IActionResult> GetEntities() {
            var result = await dbContext.Entities.ToListAsync();
            return Ok(result);
        }
    }
