    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Http;
    
    namespace Application.Controllers
    {
        public class GetDataController : ApiController
        {
            public IEnumerable<string> Get()
            {
                var user = AuthUser(HttpContext.Current);
                var dataset = new List<string>();
                // code to populate dataset
                return dataset;
            }
            //** I would put this somewhere else in your application so you can reuse it **\\
            private static User AuthUser(HttpContext httpContext)
            {
                var authHeader = httpContext.Request.Headers["Authorization"];
                if (authHeader == null || !authHeader.StartsWith("Basic"))
                    throw new Exception("The authorization header is empty or isn't Basic.");
                var encodedCredentials = authHeader.Substring("Basic".Length).Trim();
                var credentialPair = System.Text.Encoding.Unicode.GetString(Convert.FromBase64String(encodedCredentials));
                var credentials = credentialPair.Split(new[] {":"}, StringSplitOptions.None);
                var username = credentials[0];
                var password = credentials[1];
                var user = new User();
                // code to validate login & populate user model
                return user;
            }
        }
    }
