    using System;
    
    using System.Collections.Generic;
    
    using Microsoft.TeamFoundation.Client;
    
    using Microsoft.TeamFoundation.Framework.Client;
    
    using Microsoft.TeamFoundation.Framework.Common;
    
    namespace ConsoleApplication3
    
    {
    
        class Program
    
        {
            static void Main(string[] args)
    
            {
    
                TfsConfigurationServer tcs = new TfsConfigurationServer(new Uri("http://tfsserver:8080/tfs"));
    
                IIdentityManagementService ims = tcs.GetService<IIdentityManagementService>();
    
                TeamFoundationIdentity tfi = ims.ReadIdentity(IdentitySearchFactor.AccountName, "[TEAM FOUNDATION]\\Team Foundation Valid Users", MembershipQuery.Expanded, ReadIdentityOptions.None);
    
                TeamFoundationIdentity[] ids = ims.ReadIdentities(tfi.Members, MembershipQuery.None, ReadIdentityOptions.None);
    
                foreach (TeamFoundationIdentity id in ids)
    
                {
                    if (id.Descriptor.IdentityType == "System.Security.Principal.WindowsIdentity")
    
                    {
                        Console.WriteLine(id.DisplayName);
                        Console.WriteLine(id.UniqueName);
                    }
    
                }
    
                Console.ReadLine();
    
            }
        }
    }
