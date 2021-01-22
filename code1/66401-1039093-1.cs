    using System;
    using System.DirectoryServices;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (DirectoryEntry w3svc =
                     new DirectoryEntry("IIS://Localhost/W3SVC/1/root"))
                {
                    string[] defaultDocs =
                        w3svc.Properties["DefaultDoc"].Value.ToString().Split(',');
    
                }
            }
        }
    }
