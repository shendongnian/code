    public class CacheController : Controller
    {
       [HttpGet("{key}")]
       public IActionResult GetCacheValue(string key)
       {
           var cacheValue = //get your cache
           return Json(cacheValue);
       }
    }
