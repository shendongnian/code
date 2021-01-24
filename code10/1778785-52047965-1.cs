    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate)]
    public class UserKeyAuthorizeAttribute : TypeFilterAttribute
    {
        public UserKeyAuthorizeAttribute() : base(typeof(UserKeyFilter))
        {
        }
        public class UserKeyFilter : IAsyncActionFilter
        {
            public static string CalculateHash(string stringToHash)
            {
                using (var sha = SHA256.Create())
                {
                    var computedHash = sha.ComputeHash(Encoding.Unicode.GetBytes(stringToHash));
                    return Convert.ToBase64String(computedHash);
                }
            }
            
            
            private const string Hash = "signature";
            
            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                // check key
                if (!IsUserKeyValid(context.HttpContext.Request))
                {
                    context.Result = new UnauthorizedResult();
                }
                else
                {
                    await next();
                }
            }
            public static bool IsUserKeyValid(HttpRequest request)
            {
                var map = new Dictionary<string, string>();
                foreach (var header in request.Headers)
                {
                    if (header.Key.StartsWith("x-"))
                    {
                        map.Add(header.Key, header.Value);
                    }
                }
                var headerSig = "";
                
                foreach (var key in map.OrderBy(x=> x.Key))
                {
                    headerSig = headerSig + "x-" + map[key.Key] + "-";
                }
                var nonce = request.Headers["nonce"].FirstOrDefault();   
                headerSig = headerSig + nonce + "-" + Environment.GetEnvironmentVariable("ApiKey");
                var hash = CalculateHash(headerSig);
                var signature = request.Headers[Hash].FirstOrDefault<string>();                                
                return hash == signature;
            }
        }       
    }
