    public class SomeService : ISomeService
    {
        private readonly IJsonConverterService _jsonConverterService;
        public SomeService(IHttpContextAccessor httpContextAccessor, IJsonConverterService jsonConverterService)
        {
            _jsonConverterService = jsonConverterService;
            _jsonConverterService.Context = httpContextAccessor.HttpContext;
        }
        public IJsonConverterService ConverterService
        {
            get { return _jsonConverterService; }
        }
    }
