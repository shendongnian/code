    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Configuration.Install;
    using System.Runtime.InteropServices;
    namespace MyInstallerClassDll
    {
    [RunInstaller(true)]
    public partial class MyInstallerClass : Installer
    {
        const int ODBC_REMOVE_DSN = 3;
        public MyInstallerClass()
        {
            InitializeComponent();
        }
        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            RemoveSystemDSN();
            base.Uninstall(savedState);
        }
        [DllImport("ODBCCP32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int SQLConfigDataSource(int hwndParent, int fRequest, string lpszDriver, string lpszAttributes);
        private void RemoveSystemDSN()
        {
            string vAttributes = "DSN=DSN Name" + Strings.Chr(0);
            vAttributes += "Description=DSN Description" + Strings.Chr(0);
            vAttributes += "Trusted_Connection=Yes" + Strings.Chr(0);
            vAttributes += "Server=SQLINSTANCE" + Strings.Chr(0);
            vAttributes += "Database=databasename" + Strings.Chr(0);
            if (SQLConfigDataSource(0, ODBC_REMOVE_DSN, "SQL Server", vAttributes) == 0)
            {
                MessageBox.Show("Failed to remove ODBC data source!!");
            }
        }
    }
    } 
