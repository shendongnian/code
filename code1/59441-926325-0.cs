    public class Test
    {
        public static bool IsInDomain()
        {
            Win32.NetJoinStatus status = Win32.NetJoinStatus.NetSetupUnknownStatus;
            IntPtr pDomain = IntPtr.Zero;
            int result = Win32.NetGetJoinInformation(null, out pDomain, out status);
            if (result == Win32.ErrorSuccess)
            {
                if (status == Win32.NetJoinStatus.NetSetupDomainName)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new Exception("Domain Info Get Failed");
            }
        }
    }
    internal class Win32
    {
        public const int ErrorSuccess = 0;
        [DllImport("Netapi32.dll", CharSet=CharSet.Unicode, SetLastError=true)]
        public static extern int NetGetJoinInformation(string server, out IntPtr domain, out NetJoinStatus status);
        
        [DllImport("Netapi32.dll")]
        public static extern int NetApiBufferFree(IntPtr Buffer);
        public enum NetJoinStatus
        {
            NetSetupUnknownStatus = 0,
            NetSetupUnjoined,
            NetSetupWorkgroupName,
            NetSetupDomainName
        }
    }
