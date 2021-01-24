    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.Server;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace GetUser
    {
        class Program
        {
            static void Main(string[] args)
            {
                TfsTeamProjectCollection tfs = new TfsTeamProjectCollection(new Uri("http://server:8080/tfs/DefaultCollection"));
                tfs.EnsureAuthenticated();
    
                IGroupSecurityService gss = tfs.GetService<IGroupSecurityService>();
    
                Identity SIDS = gss.ReadIdentity(SearchFactor.AccountName, "Project Collection Valid Users", QueryMembership.Expanded);
    
                Identity[] UserId = gss.ReadIdentities(SearchFactor.Sid, SIDS.Members, QueryMembership.Direct);
    
                foreach (Identity user in UserId)
                {
                    if (user != null)
                    {
                        Console.WriteLine(user.AccountName);
                        Console.WriteLine(user.Domain);
                    }
                }
                Console.ReadKey();
            }
        }
    }
