    public class BasicFilter
    {
        public void Configure(IApplicationBuilder appBuilder) {
            // note the AuthencitaionMiddleware here is your Basic Authentication Middleware , 
            // not the middleware from the Microsoft.AspNetCore.Authentication;
            appBuilder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
