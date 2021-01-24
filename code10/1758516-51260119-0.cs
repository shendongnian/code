    using System;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.Framework.Client;
    using Microsoft.TeamFoundation.Framework.Common;
    using System.Linq;
    using System.IO;
    
    namespace Getuserlist
    
    {
    
        class Program
    
        {
            static void Main(string[] args)
    
            {
    
                TfsConfigurationServer tcs = new TfsConfigurationServer(new Uri("http://server:8080/tfs"));
    
                IIdentityManagementService ims = tcs.GetService<IIdentityManagementService>();
    
                TeamFoundationIdentity tfi = ims.ReadIdentity(IdentitySearchFactor.AccountName, "Project Collection Valid Users", MembershipQuery.Expanded, ReadIdentityOptions.None);
    
                TeamFoundationIdentity[] ids = ims.ReadIdentities(tfi.Members, MembershipQuery.None, ReadIdentityOptions.None);
    
                using (StreamWriter file = new StreamWriter("userlist.txt"))
    
                    foreach (TeamFoundationIdentity id in ids)
    
                    {
                        if (id.Descriptor.IdentityType == "System.Security.Principal.WindowsIdentity")
    
                        { Console.WriteLine(id.DisplayName); }
                        //{ Console.WriteLine(id.UniqueName); }
    
                        file.WriteLine("[{0}]", id.DisplayName);
                    }
    
                var count = ids.Count(x => ids.Contains(x));
                Console.WriteLine(count);
                Console.ReadLine();
            }
        }
    }
