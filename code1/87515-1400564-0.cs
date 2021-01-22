    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.DirectoryServices;
    namespace AppPoolEnum
    {
        class Program
        {
            static void Main(string[] args)
            {
                DirectoryEntries appPools = 
                    new DirectoryEntry("IIS://localhost/W3SVC/AppPools").Children;
                
                foreach (DirectoryEntry appPool in appPools)
                {
                    Console.WriteLine(appPool.Name);
                }
            }
        }
    }
