    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Security.Principal;
    using System.Security.Permissions;
    using Microsoft.Win32.SafeHandles;
    using System.Runtime.ConstrainedExecution;
    using System.Security;
    namespace WindowsFormsApp1
    {
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
       int dwLogonType, int dwLogonProvider, out SafeTokenHandle phToken);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);
        // Test harness.
        // If you incorporate this code into a DLL, be sure to demand FullTrust.
        [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
        [STAThread]
        static void Main()
        {
            try
            {
                const int LOGON32_PROVIDER_DEFAULT = 0;
                //This parameter causes LogonUser to create a primary token.
                const int LOGON32_LOGON_INTERACTIVE = 2;
                // Call LogonUser to obtain a handle to an access token.
                bool returnValue = LogonUser(PUT_YUR_LOCAL_USER_NAME, PUT_YOUR_MACHINE_HOST_NAME_OR_DOMAIN_NAME, PUT_YOUR_PASSWORD, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, out SafeTokenHandle safeTokenHandle);
                //Console.WriteLine("LogonUser called.");
                if (false == returnValue)
                {
                    int ret = Marshal.GetLastWin32Error();
                    MessageBox.Show(string.Format("LogonUser failed with error code : {0}", ret));
                    throw new System.ComponentModel.Win32Exception(ret);
                }
                using (safeTokenHandle)
                {
                    // Use the token handle returned by LogonUser.
                    using (WindowsIdentity newId = new WindowsIdentity(safeTokenHandle.DangerousGetHandle()))
                    {
                        using (WindowsImpersonationContext impersonatedUser = newId.Impersonate())
                        {
                            Application.EnableVisualStyles();
                            Application.SetCompatibleTextRenderingDefault(false);
                            Application.Run(new Form1());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occurred. " + ex.Message);
            }
        }
    }
    }
    public sealed class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
    private SafeTokenHandle()
        : base(true)
    {
    }
    [DllImport("kernel32.dll")]
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    [SuppressUnmanagedCodeSecurity]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool CloseHandle(IntPtr handle);
    protected override bool ReleaseHandle()
    {
        return CloseHandle(handle);
    }
    }
