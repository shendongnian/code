    [ResponseCache(CacheProfileName = "FilterCache", Duration = 10, Location = ResponseCacheLocation.Any, NoStore = false)]
    [Route("/accounts/filter/")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        // GET: /accounts/filter/?status_eq=test&birth_gt=643972596&country_year=1970&limit=5&query_id=110
        [HttpGet]
        public IEnumerable<string> Get([FromQuery] string status_eq, [FromQuery] long birth_gt, [FromQuery] int country_year, [FromQuery] int limit, [FromQuery] int query_id)
    )
        {
            return new string[] { "value1", "value2" };
        }
    }
