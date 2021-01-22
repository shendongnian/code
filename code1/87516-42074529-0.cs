    using System.IO;
    using Microsoft.Web.Administration;
    
    namespace AppPoolEnum
    {
        class Program
        {
            static void Main(string[] args)
            {   
                    foreach (var appPool in  new ServerManager().ApplicationPools)
                    {
                        Console.WriteLine(appPool.Name);
                    }
            }
        }
    }
