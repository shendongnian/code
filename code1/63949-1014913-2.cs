    using System;
    using DerivedClasses;
    
    namespace MethodSecuritySpike
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                Console.WriteLine("Printing ini file from security enforced method:");
                var printer1 = new FileIOPermissionExceptionThrower();
                printer1.PrintIniFile();
                Console.WriteLine();
                Console.WriteLine("Bypassing security:");
                var printer2 = new InheritanceDemandExceptionThrower();
                printer2.PrintIniFile();
                Console.ReadLine();      
            }
        }
    }
