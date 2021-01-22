    using System.Security.Permissions;
    using BaseClass;
    
    [assembly:RegistryPermission(SecurityAction.RequestRefuse,Unrestricted = true)]
    namespace DerivedClasses
    {
        public class FileIOPermissionExceptionThrower : IniPrinterBase
        {
            public override void PrintIniFile()
            {
                base.PrintIniFile();
            }
        }
    
        public class InheritanceDemandExceptionThrower : IniPrinterBase
        {
            public override void PrintIniFile()
            {
                ProtectedPrint();
            }
        }   
    }
