    public class JwtHelper : IJwtHelper
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public JwtHelper(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public  string GetValueFromToken(string propertyName)
        {
            var jwt= httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            // I can't access httpContextAccessor in this line.
            var handler = new JwtSecurityTokenHandler();
            var tokens = handler.ReadToken(jwt) as JwtSecurityToken;
            return tokens.Claims.FirstOrDefault(claim => claim.Type == propertyName).Value;
        }
    }
    public interface IJwtHelper
    {
        string GetValueFromToken(string propertyName);
    }
