    using Microsoft.Azure.Management.Compute.Fluent;
    using Microsoft.Azure.Management.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Threading.Tasks;
    
    namespace myVMDotnetProject
    {
        class Program
        {
            static void Main(string[] args)
            {
                GetVMInfo();
    
                Console.WriteLine("okok");
                Console.ReadLine();
            }
    
    
            static async Task  GetVMInfo()
            {
                var credentials = SdkContext.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION", EnvironmentVariableTarget.User));
    
                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();
    
                IVirtualMachines _client = azure.VirtualMachines;
                var list = await _client.ListAsync();
    
                foreach (var instance in list)
                {
                    var name = instance.Name;
                    var ip = instance.GetPrimaryPublicIPAddress().IPAddress;
                    Console.WriteLine("name: " + name + ", ip: " + ip);
                }
            }
    
        }
    }
