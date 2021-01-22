    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.ServiceHosting.ServiceRuntime;
    using System.Threading;
    
    namespace Plugin1
    {
        public class Class1
        {
            static void Main(string[] args)
            {
                if (args != null)
                {
                    RoleManager.WriteToLog("Information", args.ToString());
                    Console.WriteLine(args.ToString());
                }
    
                while (true)
                {
                    Thread.Sleep(1000);
                    RoleManager.WriteToLog("Information", "Hello I am plugin");
                    Console.WriteLine("Hello I am plugin");
                }
            }
        }
    }
