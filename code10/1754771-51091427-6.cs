    [Produces("application/json")]
    public abstract class BaseController<TEntity, TModel> : Controller
        where TEntity : class 
        where TModel : class {
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
        public IActionResult Get([FromRoute] string token) {
            return GetInternal(token);
        }
        protected abstract TModel Map(TEntity entity);
        protected virtual IActionResult GetInternal(string token)  
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var sql = string.Format("EXEC dbo.[AJ_P_{0}_API] @Token", GetEntityName());
            var entities = dbContext.Set<TEntity>().FromSql(sql, token).ToList();
            var returnValue = entities.Select(Map);
            return Ok(returnValue);
        }
    }
