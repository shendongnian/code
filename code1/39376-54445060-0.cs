    public class SomeOtherClass
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        public SomeOtherClass(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void TestSet()
        {
            _session.SetString("Test", "Ben Rules!");
        }
        public void TestGet()
        {
            var message = _session.GetString("Test");
        }
    }
