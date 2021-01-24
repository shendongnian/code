    public class ModelClass
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
    
        public ModelClass(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
