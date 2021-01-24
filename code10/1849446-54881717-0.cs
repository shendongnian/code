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
                // azure variable here is just for reference.. I'm not really using it further.
                // it's just to show that whatever method you're using already for Authentication (like through file or with credentials or with cert
                // same can be used to get AzureCredentials as well, just change the FromFile to FromServicePrincipal..
                IAzure azure = Azure.Authenticate("my.azureauth").WithDefaultSubscription();
                var creds = SdkContext.AzureCredentialsFactory.FromFile("my.azureauth");
    
                IGraphRbacManager graphRbacManager = GraphRbacManager.Authenticate(creds, "<your tenant Guid>");
    
                var domains = graphRbacManager.Inner.Domains.ListAsync().GetAwaiter().GetResult();
                // I'm just looping through and displaying on console..
                // but you will make use of one of these to form identifierURI..
      
                foreach (var domain in domains)
                {
                    // also look at isDefault and isVerified properties if they help you 
                    Console.WriteLine(domain.Name);
                }
    
                Console.ReadLine();
            }        
        }
    }
