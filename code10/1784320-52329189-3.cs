    public class UrlRules : IRule
        {
            public void ApplyRule(RewriteContext context)
            {
                var request = context.HttpContext.Request;
                if (!IsValidUrl(request.Path))
                {
                    var response = context.HttpContext.Response;
                    response.StatusCode = StatusCodes.Status404NotFound;
                    context.Result = RuleResult.EndResponse;
                    response.Headers[HeaderNames.Location] = "/home/error";
                    
                }
            }
            public bool IsValidUrl(string path)
            {
                bool urlValid = false;
                switch (path)
                {
                    case "/":
                    case "/about-us":
                    case "/about-us/":
                    case "/GetCountryInfo":
                    case "/pricing":
                    case "/pricing/":
                    case "/sign-in":
                    case "/sign-in/":
                    case "/sign-up":
                    case "/sign-up/":
                        urlValid = true;
                        break;
                    default:
                        urlValid = false;
                        break;
                }
                return urlValid;
            }
        }
