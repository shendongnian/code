    using System;
    using System.Runtime.InteropServices;
    
    namespace HRTC.CustomActions.Helpers
    {
        public static class ServiceRecoveryOptionHelper
        {
            //Action Enum
            public enum RecoverAction
            {
                None = 0, Restart = 1, Reboot = 2, RunCommand = 3
            }
    
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    
            public struct ServiceFailureActions
            {
                public int dwResetPeriod;
                [MarshalAs(UnmanagedType.LPWStr)]
    
                public string lpRebootMsg;
                [MarshalAs(UnmanagedType.LPWStr)]
    
                public string lpCommand;
                public int cActions;
                public IntPtr lpsaActions;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            public class ScAction
            {
                public int type;
                public uint dwDelay;
            }
    
            // Win32 function to open the service control manager
            [DllImport("advapi32.dll")]
            public static extern IntPtr OpenSCManager(string lpMachineName, string lpDatabaseName, int dwDesiredAccess);
    
            // Win32 function to open a service instance
            [DllImport("advapi32.dll")]
            public static extern IntPtr OpenService(IntPtr hScManager, string lpServiceName, int dwDesiredAccess);
    
            // Win32 function to change the service config for the failure actions.
            [DllImport("advapi32.dll", EntryPoint = "ChangeServiceConfig2")]
    
            public static extern bool ChangeServiceFailureActions(IntPtr hService, int dwInfoLevel,
                [MarshalAs(UnmanagedType.Struct)]
                ref ServiceFailureActions lpInfo);
    
            [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true, EntryPoint = "QueryServiceConfig2W")]
            public static extern Boolean QueryServiceConfig2(IntPtr hService, UInt32 dwInfoLevel, IntPtr buffer, UInt32 cbBufSize, out UInt32 pcbBytesNeeded);
    
            [DllImport("kernel32.dll")]
            public static extern int GetLastError();
        }
        public class FailureAction
        {
            // Default constructor
            public FailureAction() { }
    
            // Constructor
            public FailureAction(ServiceRecoveryOptionHelper.RecoverAction actionType, int actionDelay)
            {
                Type = actionType;
                Delay = actionDelay;
            }
    
            // Property to set recover action type
            public ServiceRecoveryOptionHelper.RecoverAction Type { get; set; } = ServiceRecoveryOptionHelper.RecoverAction.None;
    
            // Property to set recover action delay
            public int Delay { get; set; }
        }
    }
