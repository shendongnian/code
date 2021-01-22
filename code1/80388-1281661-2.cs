    using System;
    using System.IO;
    using System.Security.AccessControl;
    using System.Security.Principal;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string directory = @"C:\downloads";
    
                DirectoryInfo di = new DirectoryInfo(directory);
    
                DirectorySecurity ds = di.GetAccessControl();
    
                foreach (AccessRule rule in ds.GetAccessRules(true, true, typeof(NTAccount)))
                {
                    Console.WriteLine("Identity = {0}; Access = {1}", 
                                  rule.IdentityReference.Value, rule.AccessControlType);
                }
            }
        }
    }
