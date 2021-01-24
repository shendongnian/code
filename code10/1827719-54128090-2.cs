    using System;
    using System.Security.Principal;
    namespace UserApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Is64BitProcess " + Environment.Is64BitProcess);
                Console.WriteLine("Running As " + WindowsIdentity.GetCurrent().Name);
                var type = Type.GetTypeFromProgID("AdminApp.AdminClass");
                dynamic trustedClass = Activator.CreateInstance(type);
                Console.WriteLine("Admin App Process Path: " + trustedClass.CurrentProcessFilePath);
                Console.WriteLine("Admin App Runnind As: " + trustedClass.WindowsIdentityCurrentName);
                Console.WriteLine("Admin App Is64BitProcess: " + trustedClass.Is64BitProcess);
                Console.WriteLine("Admin App DoSomethingAsAdmin: " + trustedClass.DoSomethingAsAdmin());
            }
        }
    }
