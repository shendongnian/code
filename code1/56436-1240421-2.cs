    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication2
    {
      class Program
      {
        public struct CRYPTUI_WIZ_IMPORT_SRC_INFO
        {
          public Int32 dwSize;
          public Int32 dwSubjectChoice;
          [MarshalAs(UnmanagedType.LPWStr)]public String pwszFileName;
          public Int32 dwFlags;
          [MarshalAs(UnmanagedType.LPWStr)]public String pwszPassword;
        }
    
        [DllImport("CryptUI.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern Boolean CryptUIWizImport(
          Int32 dwFlags,
          IntPtr hwndParent,
          IntPtr pwszWizardTitle,
          ref CRYPTUI_WIZ_IMPORT_SRC_INFO pImportSrc,
          IntPtr hDestCertStore
        );
    
        [DllImport("CRYPT32.DLL", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CertOpenStore(
          int storeProvider,
          int encodingType,
          IntPtr hcryptProv,
          int flags,
          String pvPara
        );
    
        public const Int32 CRYPTUI_WIZ_IMPORT_SUBJECT_FILE = 1;
        public const Int32 CRYPT_EXPORTABLE = 0x00000001;
        public const Int32 CRYPT_USER_PROTECTED = 0x00000002;
        public const Int32 CRYPTUI_WIZ_NO_UI = 0x0001;
    
        private static int CERT_STORE_PROV_SYSTEM = 10;
        private static int CERT_SYSTEM_STORE_CURRENT_USER = (1 << 16);
        private static int CERT_SYSTEM_STORE_LOCAL_MACHINE = (2 << 16);
    
        static void Main(string[] args)
        {
          if (args.Length != 1)
          {
            Console.WriteLine("Usage: certimp.exe list.crl");
            Environment.ExitCode = 1;
          }
          else
          {
            IntPtr hLocalCertStore = CertOpenStore(
              CERT_STORE_PROV_SYSTEM,
              0,
              IntPtr.Zero,
              CERT_SYSTEM_STORE_LOCAL_MACHINE,
              "ROOT"
            );
    
            CRYPTUI_WIZ_IMPORT_SRC_INFO importSrc = new CRYPTUI_WIZ_IMPORT_SRC_INFO();
            importSrc.dwSize = Marshal.SizeOf(importSrc);
            importSrc.dwSubjectChoice = CRYPTUI_WIZ_IMPORT_SUBJECT_FILE;
            importSrc.pwszFileName = args[0];
            importSrc.pwszPassword = null;
            importSrc.dwFlags = CRYPT_EXPORTABLE | CRYPT_USER_PROTECTED;
    
            if (!CryptUIWizImport(
                CRYPTUI_WIZ_NO_UI,
                IntPtr.Zero,
                IntPtr.Zero,
                ref importSrc,
                hLocalCertStore
              ))
            {
              Console.WriteLine("CryptUIWizImport error " + Marshal.GetLastWin32Error());
              Environment.ExitCode = -1;
            }
          }
        }
      }
    }
