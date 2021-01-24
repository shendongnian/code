    using System;
    using Microsoft.Azure.Management.Fluent;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                // whatever method you're using already for Authentication (like through file or with credentials or with cert
                // same can be used to get AzureCredentials as well, just change the FromFile to FromServicePrincipal if required
                IAzure azure = Azure.Authenticate("my.azureauth").WithDefaultSubscription();
                var creds = SdkContext.AzureCredentialsFactory.FromFile("my.azureauth");
    
                IGraphRbacManager graphRbacManager = GraphRbacManager.Authenticate(creds, "<your tenant Guid>");    
                var domains = graphRbacManager.Inner.Domains.ListAsync().GetAwaiter().GetResult();
                string defaultDomain = string.Empty;
                foreach (var domain in domains)
                {  
                    Console.WriteLine(domain.Name);
                    if (domain.IsDefault.HasValue && domain.IsDefault.Value == true)
                        defaultDomain = domain.Name;                
                        // not breaking out of loop on purpose, just to print all domain names if multiple are there.
                }
                string identiferUri = string.Format("https://{0}/myuniqueapp1", defaultDomain);
                var app = azure.AccessManagement.ActiveDirectoryApplications
                    .Define("My Unique App 1")
                    .WithSignOnUrl("https://myuniqueapp1.azurewebsites.net")
                    .WithAvailableToOtherTenants(true)
                    .WithIdentifierUrl(identiferUri)
                    .DefinePasswordCredential("string")
                    .WithPasswordValue("string")
                    .WithDuration(new TimeSpan(365,0,0,0))
                    .Attach()
                    .CreateAsync();
    
                Console.ReadLine();
            }        
        }
    }
