    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using AspNet.Security.OpenIdConnect.Extensions;
    using AspNet.Security.OpenIdConnect.Primitives;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.FileProviders;
    using OpenIddict.Server;
    using Owin;
    
    namespace OpenIddictOwinDemo
    {
        using AddMiddleware = Action<Func<
            Func<IDictionary<string, object>, Task>,
            Func<IDictionary<string, object>, Task>
        >>;
        using AppFunc = Func<IDictionary<string, object>, Task>;
    
        public static class KatanaExtensions
        {
            public static IAppBuilder UseBuilder(this IAppBuilder app,
                IServiceProvider provider, Action<IApplicationBuilder> configuration)
            {
                if (app == null)
                {
                    throw new ArgumentNullException(nameof(app));
                }
    
                if (provider == null)
                {
                    throw new ArgumentNullException(nameof(provider));
                }
    
                if (configuration == null)
                {
                    throw new ArgumentNullException(nameof(configuration));
                }
    
                AddMiddleware add = middleware =>
                {
                    return app.Use(new Func<AppFunc, AppFunc>(next => middleware(next)));
                };
                add.UseBuilder(configuration, provider);
    
                return app;
            }
        }
    
        public static class CustomOpenIddictServerExtensions
        {
            public static OpenIddictServerBuilder UseCustomTokenEndpoint(
                this OpenIddictServerBuilder builder)
            {
                if (builder == null)
                {
                    throw new ArgumentNullException(nameof(builder));
                }
    
                return builder.AddEventHandler<OpenIddictServerEvents.HandleTokenRequest>(
                    notification =>
                    {
                        var request = notification.Context.Request;
                        if (!request.IsPasswordGrantType())
                        {
                            return Task.CompletedTask;
                        }
    
                        // Validate the user credentials.
    
                        // Note: to mitigate brute force attacks, you SHOULD strongly consider
                        // applying a key derivation function like PBKDF2 to slow down
                        // the password validation process. You SHOULD also consider
                        // using a time-constant comparer to prevent timing attacks.
                        if (request.Username != "alice@wonderland.com" ||
                            request.Password != "P@ssw0rd")
                        {
                            notification.Context.Reject(
                                error: OpenIdConnectConstants.Errors.InvalidGrant,
                                description: "The specified credentials are invalid.");
    
                            return Task.CompletedTask;
                        }
    
                        // Create a new ClaimsIdentity holding the user identity.
                        var identity = new ClaimsIdentity(
                                notification.Context.Scheme.Name,
                                OpenIdConnectConstants.Claims.Name,
                                OpenIdConnectConstants.Claims.Role);
    
                        // Add a "sub" claim containing the user identifier, and attach
                        // the "access_token" destination to allow OpenIddict to store it
                        // in the access token, so it can be retrieved from your controllers.
                        identity.AddClaim(OpenIdConnectConstants.Claims.Subject,
                                "71346D62-9BA5-4B6D-9ECA-755574D628D8",
                                OpenIdConnectConstants.Destinations.AccessToken);
                        identity.AddClaim(OpenIdConnectConstants.Claims.Name, "Alice",
                            OpenIdConnectConstants.Destinations.AccessToken);
    
                        // ... add other claims, if necessary.
                        var principal = new ClaimsPrincipal(identity);
                        notification.Context.Validate(principal);
    
                        return Task.CompletedTask;
                    });
            }
        }
    
        public class HostingEnvironment : IHostingEnvironment
        {
            public string EnvironmentName { get; set; }
            public string ApplicationName { get; set; }
            public string WebRootPath { get; set; }
            public IFileProvider WebRootFileProvider { get; set; }
            public string ContentRootPath { get; set; }
            public IFileProvider ContentRootFileProvider { get; set; }
        }
    }
