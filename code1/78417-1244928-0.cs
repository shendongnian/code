    public class HomeController : Controller
    {
        private IMemoryCache _cache;
    
        public HomeController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
            var onlineAt = _cache.Get<DateTime?>("self:startup");
        }
