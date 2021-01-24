    public class CustomerRepository
    {
        private readonly IHttpContextAccessor _context;
    
        public CustomerRepository(IHttpContextAccessor context)
        {
            _context = context;
        }
    
        public string BaseUrl()
        {
            var request = _context.HttpContext.Request;
            // Now that you have the request you can select what you need from it.
            return string.Empty;
        }
    }
