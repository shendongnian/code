    namespace TokenGenerator
    {
        class Program
        {
            private static string token = string.Empty;
        
            static void Main(string[] args)
            {
                //Get an authentication access token
                token = GetToken();
            }
    
            #region Get an authentication access token
            private static string GetToken()
            {
                // TODO: Install-Package Microsoft.IdentityModel.Clients.ActiveDirectory -Version 2.21.301221612
                // and add using Microsoft.IdentityModel.Clients.ActiveDirectory
    
                //The client id that Azure AD created when you registered your client app.
                string clientID = "Your client ID";
    
                string AuthEndPoint = "https://login.microsoftonline.com/{0}/oauth2/token";
                string TenantId = "Your Tenant ID";
    
                //RedirectUri you used when you register your app.
                //For a client app, a redirect uri gives Azure AD more details on the application that it will authenticate.
                // You can use this redirect uri for your client app
                string redirectUri = "https://login.microsoftonline.com/common/oauth2/nativeclient";
    
                //Resource Uri for Power BI API
                string resourceUri = "https://analysis.windows.net/powerbi/api";
    
                //Get access token:
                // To call a Power BI REST operation, create an instance of AuthenticationContext and call AcquireToken
                // AuthenticationContext is part of the Active Directory Authentication Library NuGet package
                // To install the Active Directory Authentication Library NuGet package in Visual Studio,
                //  run "Install-Package Microsoft.IdentityModel.Clients.ActiveDirectory" from the nuget Package Manager Console.
    
                // AcquireToken will acquire an Azure access token
                // Call AcquireToken to get an Azure token from Azure Active Directory token issuance endpoint
                string authority = string.Format(CultureInfo.InvariantCulture, AuthEndPoint, TenantId);
                AuthenticationContext authContext = new AuthenticationContext(authority);
                string token = authContext.AcquireTokenAsync(resourceUri, clientID, new Uri(redirectUri), new PlatformParameters(PromptBehavior.Auto)).Result.AccessToken;
                Console.WriteLine(token);
                Console.ReadLine();
                return token;
            }
            #endregion
    
        }
    }
