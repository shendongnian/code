        protected ServiceBase(
            IHttpContextAccessor contextAccessor, 
            IJwtTokenService jwtTokenService, 
            IMemoryCache memoryCache = null)
        {
            MemoryCache = memoryCache ?? new MemoryCache(new MemoryCacheOptions());
            CachingFunctionalty = new CachingFunctionality();
            HttpContextAccessor = contextAccessor;
            JwtTokenService = jwtTokenService;
        }
        protected RestClient CreateClient()
        {
            RestClient restClient = new RestClient(ServiceAdress);
            var token = HttpContextAccessor.HttpContext.Request.Cookies["access_token"];
            if (string.IsNullOrWhiteSpace(token)) return restClient;
            var unprotected = JwtTokenService.UnprotectToken(token);
            restClient.AuthenticationHeaderValue = new AuthenticationHeaderValue("Bearer", unprotected);
            return restClient;
        }
