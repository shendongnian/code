    using System;
    using System.Security.Principal; 
    
    class Test
    {
        public static void Main()
        {
            if (new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
            {
                Console.WriteLine("I am an admin.");
            }
        }
    }
