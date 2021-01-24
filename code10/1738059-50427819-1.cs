    public class CookieTokenProvider : ITokenProvider
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public CookieTokenProvider(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public string GetToken()
        {
            if (httpContextAccessor.HttpContext.Request.Cookies
                                               .TryGetValue("token", out string tokenValue))
            {
                return tokenValue;
            }
            return null;
        }
    }
