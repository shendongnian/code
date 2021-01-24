    using Microsoft.AspNetCore.Mvc.Filters;
    using Newtonsoft.Json;
    
    namespace Applciation.ActionFilters
    {
        public class AuthorizeJWT: ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                var jwt = context.HttpContext.Request.Headers["JWT"];
    
                try
                {
                    var json = new JwtBuilder()
                        .WithSecret(File.ReadLines("").ToList().First())
                        .MustVerifySignature()
                        .Decode(jwt);                    
    
                    var tokenDetails = JsonConvert.DeserializeObject<dynamic>(json);
                }
                catch (TokenExpiredException)
                {
                    throw new Exception("Token is expired");
                }
                catch (SignatureVerificationException)
                {
                    throw new Exception("Token signature invalid");
                }
                catch(Exception ex)
                {
                  throw new Exception("Token has been tempered with");
                }
            }
        }
    }
