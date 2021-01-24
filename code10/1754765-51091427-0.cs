    [Produces("application/json")]
    public abstract class BaseController<TEntity> : Controller
        where TEntity : class {
        // Returns the name of an entity as it is used in stored procedures, class names, etc...
        protected virtual string GetEntityName() {
            return typeof(TEntity).Name;
        }
        
        // SiteContext is the API site's data context.
        protected readonly SiteContext dbContext;
        protected BaseController(SiteContext context) {
            dbContext = context;
        }
        [HttpGet("{token}")]
        public virtual IActionResult Get([FromRoute] string token) {
            return Results(token);
        }
        protected IActionResult Results(string token)  
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var returnValue = dbContext.Set<TEntity>().FromSql("EXEC dbo.[AJ_P_{0}_API] @Token={1}", GetEntityName(), token).ToList();
            return Ok(returnValue);
        }
    }
