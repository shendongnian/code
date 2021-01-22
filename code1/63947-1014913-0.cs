    using System;
    using System.IO;
    using System.Security;
    using System.Security.Permissions;
    
    namespace BaseClass
    {
        public abstract class IniPrinterBase
        {
            [FileIOPermission(SecurityAction.Deny, AllFiles = FileIOPermissionAccess.Read)]
            //[RegistryPermission(SecurityAction.InheritanceDemand,Unrestricted = true)]
            public virtual void PrintIniFile()
            {
                ProtectedPrint();
            }
    
            protected void ProtectedPrint()
            {
                try
                {
                    var lines = File.ReadAllLines(@"G:\test.ini");
                    foreach (var line in lines)
                    {
                        Console.WriteLine(line);
                    }
                }
                catch (SecurityException e)
                {
    
                    Console.WriteLine("PRINT OF INI FILE FAILED!");
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
