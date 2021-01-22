    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Security.AccessControl;
    
    
    namespace ConsoleApplication1
    {
        class Program
        {
            [DllImport("advapi32.dll", SetLastError = true)]
            static extern uint GetEffectiveRightsFromAcl(IntPtr pDacl, ref TRUSTEE pTrustee, ref ACCESS_MASK pAccessRights);
    
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
            struct TRUSTEE
            {
                IntPtr pMultipleTrustee; // must be null
                public int MultipleTrusteeOperation;
                public TRUSTEE_FORM TrusteeForm;
                public TRUSTEE_TYPE TrusteeType;
                [MarshalAs(UnmanagedType.LPStr)]
                public string ptstrName;
            }
    
            enum TRUSTEE_FORM
            {
                TRUSTEE_IS_SID,
                TRUSTEE_IS_NAME,
                TRUSTEE_BAD_FORM,
                TRUSTEE_IS_OBJECTS_AND_SID,
                TRUSTEE_IS_OBJECTS_AND_NAME
            }
    
            enum TRUSTEE_TYPE {
              TRUSTEE_IS_UNKNOWN,
              TRUSTEE_IS_USER,
              TRUSTEE_IS_GROUP,
              TRUSTEE_IS_DOMAIN,
              TRUSTEE_IS_ALIAS,
              TRUSTEE_IS_WELL_KNOWN_GROUP,
              TRUSTEE_IS_DELETED,
              TRUSTEE_IS_INVALID,
              TRUSTEE_IS_COMPUTER 
            } 
    
            [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
            static extern uint GetNamedSecurityInfo(
                string pObjectName,
                SE_OBJECT_TYPE ObjectType,
                SECURITY_INFORMATION SecurityInfo,
                out IntPtr pSidOwner,
                out IntPtr pSidGroup,
                out IntPtr pDacl,
                out IntPtr pSacl,
                out IntPtr pSecurityDescriptor);
            
            enum ACCESS_MASK : uint
            {
                DELETE = 0x00010000,
                READ_CONTROL = 0x00020000,
                WRITE_DAC = 0x00040000,
                WRITE_OWNER = 0x00080000,
                SYNCHRONIZE = 0x00100000,
    
                STANDARD_RIGHTS_REQUIRED = 0x000f0000,
    
                STANDARD_RIGHTS_READ = 0x00020000,
                STANDARD_RIGHTS_WRITE = 0x00020000,
                STANDARD_RIGHTS_EXECUTE = 0x00020000,
    
                STANDARD_RIGHTS_ALL = 0x001f0000,
    
                SPECIFIC_RIGHTS_ALL = 0x0000ffff,
    
                ACCESS_SYSTEM_SECURITY = 0x01000000,
    
                MAXIMUM_ALLOWED = 0x02000000,
    
                GENERIC_READ = 0x80000000,
                GENERIC_WRITE = 0x40000000,
                GENERIC_EXECUTE = 0x20000000,
                GENERIC_ALL = 0x10000000,
    
                DESKTOP_READOBJECTS = 0x00000001,
                DESKTOP_CREATEWINDOW = 0x00000002,
                DESKTOP_CREATEMENU = 0x00000004,
                DESKTOP_HOOKCONTROL = 0x00000008,
                DESKTOP_JOURNALRECORD = 0x00000010,
                DESKTOP_JOURNALPLAYBACK = 0x00000020,
                DESKTOP_ENUMERATE = 0x00000040,
                DESKTOP_WRITEOBJECTS = 0x00000080,
                DESKTOP_SWITCHDESKTOP = 0x00000100,
    
                WINSTA_ENUMDESKTOPS = 0x00000001,
                WINSTA_READATTRIBUTES = 0x00000002,
                WINSTA_ACCESSCLIPBOARD = 0x00000004,
                WINSTA_CREATEDESKTOP = 0x00000008,
                WINSTA_WRITEATTRIBUTES = 0x00000010,
                WINSTA_ACCESSGLOBALATOMS = 0x00000020,
                WINSTA_EXITWINDOWS = 0x00000040,
                WINSTA_ENUMERATE = 0x00000100,
                WINSTA_READSCREEN = 0x00000200,
    
                WINSTA_ALL_ACCESS = 0x0000037f
            }
    
            [Flags]
            enum SECURITY_INFORMATION : uint
            {
                OWNER_SECURITY_INFORMATION = 0x00000001,
                GROUP_SECURITY_INFORMATION = 0x00000002,
                DACL_SECURITY_INFORMATION = 0x00000004,
                SACL_SECURITY_INFORMATION = 0x00000008,
                UNPROTECTED_SACL_SECURITY_INFORMATION = 0x10000000,
                UNPROTECTED_DACL_SECURITY_INFORMATION = 0x20000000,
                PROTECTED_SACL_SECURITY_INFORMATION = 0x40000000,
                PROTECTED_DACL_SECURITY_INFORMATION = 0x80000000
            }
    
            enum SE_OBJECT_TYPE
            {
                SE_UNKNOWN_OBJECT_TYPE = 0,
                SE_FILE_OBJECT,
                SE_SERVICE,
                SE_PRINTER,
                SE_REGISTRY_KEY,
                SE_LMSHARE,
                SE_KERNEL_OBJECT,
                SE_WINDOW_OBJECT,
                SE_DS_OBJECT,
                SE_DS_OBJECT_ALL,
                SE_PROVIDER_DEFINED_OBJECT,
                SE_WMIGUID_OBJECT,
                SE_REGISTRY_WOW64_32KEY
            }
    
    
            static void Main(string[] args)
            {            
    
    	    String user = "DOMAIN\\USER";
    	    String Path = "C:\\";
    
                IntPtr pSidOwner, pSidGroup, pDacl, pSacl, pSecurityDescriptor;
                ACCESS_MASK mask = new ACCESS_MASK();
                uint ret = GetNamedSecurityInfo(Path, 
                    SE_OBJECT_TYPE.SE_FILE_OBJECT, 
                    SECURITY_INFORMATION.DACL_SECURITY_INFORMATION,
                    out pSidOwner, out pSidGroup, out pDacl, out pSacl, out pSecurityDescriptor);
    
                TRUSTEE t = new TRUSTEE();
                t.TrusteeForm = TRUSTEE_FORM.TRUSTEE_IS_NAME;
                t.TrusteeType= TRUSTEE_TYPE.TRUSTEE_IS_USER;
                t.ptstrName = user;
                ret = GetEffectiveRightsFromAcl(pDacl, ref t , ref mask);
    
                if ((mask & ACCESS_MASK.READ_CONTROL) == ACCESS_MASK.READ_CONTROL)
                {
                    System.Diagnostics.Debug.WriteLine("Read");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("No Read");
                }
                
            }
        }
    }
