System.InvalidOperationException: IDX20803: Unable to obtain configuration from: '[PII is hidden]'. ---> System.IO.IOException: IDX20804: Unable to retrieve document from: '[PII is hidden]'. ---> System.Net.Http.HttpRequestException: Response status code does not indicate success: 400 (Bad Request).
   at System.Net.Http.HttpResponseMessage.EnsureSuccessStatusCode()
   at Microsoft.IdentityModel.Protocols.HttpDocumentRetriever.GetDocumentAsync(String address, CancellationToken cancel)   --- End of inner exception stack trace ---
   at Microsoft.IdentityModel.Protocols.HttpDocumentRetriever.GetDocumentAsync(String address, CancellationToken cancel)   at Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectConfigurationRetriever.GetAsync(String address, IDocumentRetriever retriever, CancellationToken cancel)
   at Microsoft.IdentityModel.Protocols.ConfigurationManager`1.GetConfigurationAsync(CancellationToken cancel)
   --- End of inner exception stack trace ---
   at Microsoft.IdentityModel.Protocols.ConfigurationManager`1.GetConfigurationAsync(CancellationToken cancel)
   at Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectHandler.HandleChallengeAsync(AuthenticationProperties properties)
   at Microsoft.AspNetCore.Authentication.AuthenticationHandler`1.ChallengeAsync(AuthenticationProperties properties)
   at Microsoft.AspNetCore.Authentication.AuthenticationService.ChallengeAsync(HttpContext context, String scheme, AuthenticationProperties properties)
   at Microsoft.AspNetCore.Mvc.ChallengeResult.ExecuteResultAsync(ActionContext context)
   at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.InvokeResultAsync(IActionResult result)
   at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.InvokeAlwaysRunResultFilters()
   at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.InvokeFilterPipelineAsync()
   at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.InvokeAsync()
   at Microsoft.AspNetCore.Builder.RouterMiddleware.Invoke(HttpContext httpContext)
   at Microsoft.AspNetCore.Builder.Extensions.MapWhenMiddleware.Invoke(HttpContext context)
   HIDDEN LINE
   at Microsoft.AspNetCore.StaticFiles.StaticFileMiddleware.Invoke(HttpContext context)
   at Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.FeaturePolicyMiddleware.Invoke(HttpContext context)
   at Joonasw.AspNetCore.SecurityHeaders.ReferrerPolicy.ReferrerPolicyMiddleware.Invoke(HttpContext context)
   at Joonasw.AspNetCore.SecurityHeaders.XContentTypeOptions.XContentTypeOptionsMiddleware.Invoke(HttpContext context)
   at Joonasw.AspNetCore.SecurityHeaders.XXssProtection.XXssProtectionMiddleware.Invoke(HttpContext context)
   at Joonasw.AspNetCore.SecurityHeaders.XFrameOptions.XFrameOptionsMiddleware.Invoke(HttpContext context)
   at Joonasw.AspNetCore.SecurityHeaders.Csp.CspMiddleware.Invoke(HttpContext context)
   at Microsoft.AspNetCore.Authentication.AuthenticationMiddleware.Invoke(HttpContext context)
   at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.Invoke(HttpContext context)
System.InvalidOperationException: IDX20803: Unable to obtain configuration from: '[PII is hidden]'. ---> System.IO.IOException: IDX20804: Unable to retrieve document from: '[PII is hidden]'. ---> System.Net.Http.HttpRequestException: Response status code does not indicate success: 404 (Not Found).
   at System.Net.Http.HttpResponseMessage.EnsureSuccessStatusCode()
   at Microsoft.IdentityModel.Protocols.HttpDocumentRetriever.GetDocumentAsync(String address, CancellationToken cancel)   --- End of inner exception stack trace ---
   at Microsoft.IdentityModel.Protocols.HttpDocumentRetriever.GetDocumentAsync(String address, CancellationToken cancel)   at Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectConfigurationRetriever.GetAsync(String address, IDocumentRetriever retriever, CancellationToken cancel)
   at Microsoft.IdentityModel.Protocols.ConfigurationManager`1.GetConfigurationAsync(CancellationToken cancel)
   --- End of inner exception stack trace ---
   at Microsoft.IdentityModel.Protocols.ConfigurationManager`1.GetConfigurationAsync(CancellationToken cancel)
   at Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectHandler.HandleChallengeAsync(AuthenticationProperties properties)
   at Microsoft.AspNetCore.Authentication.AuthenticationHandler`1.ChallengeAsync(AuthenticationProperties properties)
   at Microsoft.AspNetCore.Authentication.AuthenticationService.ChallengeAsync(HttpContext context, String scheme, AuthenticationProperties properties)
   at Microsoft.AspNetCore.Mvc.ChallengeResult.ExecuteResultAsync(ActionContext context)
   at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.InvokeResultAsync(IActionResult result)
   at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.InvokeAlwaysRunResultFilters()
   at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.InvokeFilterPipelineAsync()
   at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.InvokeAsync()
   at Microsoft.AspNetCore.Builder.RouterMiddleware.Invoke(HttpContext httpContext)
   at Microsoft.AspNetCore.Builder.Extensions.MapWhenMiddleware.Invoke(HttpContext context)
   HIDDEN LINE
   at Microsoft.AspNetCore.StaticFiles.StaticFileMiddleware.Invoke(HttpContext context)
   at Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.FeaturePolicyMiddleware.Invoke(HttpContext context)
   at Joonasw.AspNetCore.SecurityHeaders.ReferrerPolicy.ReferrerPolicyMiddleware.Invoke(HttpContext context)
   at Joonasw.AspNetCore.SecurityHeaders.XContentTypeOptions.XContentTypeOptionsMiddleware.Invoke(HttpContext context)
   at Joonasw.AspNetCore.SecurityHeaders.XXssProtection.XXssProtectionMiddleware.Invoke(HttpContext context)
   at Joonasw.AspNetCore.SecurityHeaders.XFrameOptions.XFrameOptionsMiddleware.Invoke(HttpContext context)
   at Joonasw.AspNetCore.SecurityHeaders.Csp.CspMiddleware.Invoke(HttpContext context)
   at Microsoft.AspNetCore.Authentication.AuthenticationMiddleware.Invoke(HttpContext context)
   at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.Invoke(HttpContext context)
Other articles that discuss this error.
https://github.com/IdentityServer/IdentityServer4/issues/2337
https://github.com/IdentityServer/IdentityServer4/issues/2672
https://github.com/okta/samples-aspnetcore/issues/10
https://github.com/IdentityServer/IdentityServer4/issues/2186
Solution:
Turns out I did not have AzureAD configured in `appsettings.json`. I had forgot to set my `User Secrets` to configure AzureAD with valid credentials. 
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/9AiTg.png
You will need to set the below credentials to your own for AzureAd.
JSON
{
  "AzureAd": {
    "TenantId": "SOMETHING.onmicrosoft.com",
    "ClientId": "SOMETHING",
    "ClientSecret": "SOMETHING"
  }
}
