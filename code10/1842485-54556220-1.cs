            using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Text;
            using System.Threading.Tasks;
            using Microsoft.Azure.ActiveDirectory.GraphClient;
            using Microsoft.IdentityModel.Clients.ActiveDirectory;
            namespace CreateAzureADApplication
            {
                class Program
                {
                    static void Main(string[] args)
                    {
                        ActiveDirectoryClient directoryClient;
                        ActiveDirectoryClient activeDirectoryClient = new ActiveDirectoryClient(new Uri("https://graph.windows.net/{yourAADGUID}"),
                async () => await GetTokenForApplication());
            
                        Application app = new Application();
                        app.DisplayName = "My Azure AD Native App";
                        app.PublicClient = true;
                        app.Homepage = "https://myazureadnativeapp";
                        activeDirectoryClient.Applications.AddApplicationAsync(app).GetAwaiter().GetResult();
    
                     }
                 public static async Task<string> GetTokenForApplication()
                 {
                       AuthenticationContext authenticationContext = new AuthenticationContext(
                    "https://login.microsoftonline.com/{yourAADGUID}",
                    false);
                // Configuration for OAuth client credentials 
                
                    ClientCredential clientCred = new ClientCredential("yourappclientId",
                        "yourappclientsecret"
                        );
                    AuthenticationResult authenticationResult =
                        await authenticationContext.AcquireTokenAsync("https://graph.windows.net", clientCred);
                    
                    return authenticationResult.AccessToken;
                           
                }
              }
            }
