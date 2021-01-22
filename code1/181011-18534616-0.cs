    public class Reboot
    {
        public const uint FILE_DEVICE_HAL = 0x00000101;
        public const uint METHOD_BUFFERED = 0;
        public const uint FILE_ANY_ACCESS = 0;
        public static uint CTL_CODE(uint DeviceType, uint Function, uint Method, uint Access)
        {
            return ((DeviceType << 16) | (Access << 14) | (Function << 2) | Method);
        }
        [DllImport("Coredll.dll")]
        public extern static uint KernelIoControl
        (
            uint dwIoControlCode,
            IntPtr lpInBuf,
            uint nInBufSize,
            IntPtr lpOutBuf,
            uint nOutBufSize,
            ref uint lpBytesReturned
        );
        /// <summary>
        /// Causes the CE device to soft/warm reset
        /// </summary>
        public static uint SoftReset()
        {
            uint bytesReturned = 0;
            uint IOCTL_HAL_REBOOT = CTL_CODE(FILE_DEVICE_HAL, 15, METHOD_BUFFERED, FILE_ANY_ACCESS);
            SetCleanRebootFlag();
            return KernelIoControl(IOCTL_HAL_REBOOT, IntPtr.Zero, 0, IntPtr.Zero, 0, ref bytesReturned);
        }
        [DllImport("coredll.dll")]
        public extern static uint SetSystemPowerState
        (
            String psState,
            Int32 StateFlags,
            Int32 Options
        );
        const int POWER_FORCE = 4096;
        const int POWER_STATE_RESET = 0x00800000;
        public static uint ColdReset()
        {
            SetCleanRebootFlag();
            return SetSystemPowerState(null, POWER_STATE_RESET, POWER_FORCE);
        }
        [DllImport("Coredll.dll")]
        public extern static int KernelIoControl(int dwIoControlCode, IntPtr lpInBuf, int nInBufSize, IntPtr lpOutBuf, int nOutBufSize, ref int lpBytesReturned);
        [DllImport("Coredll.dll")]
        public extern static void SetCleanRebootFlag();
        public static void HardReset()
        {
            int IOCTL_HAL_REBOOT = 0x101003C;
            int bytesReturned = 0;
            SetCleanRebootFlag();
            KernelIoControl(IOCTL_HAL_REBOOT, IntPtr.Zero, 0, IntPtr.Zero, 0, ref bytesReturned);
        }
        [DllImport("aygshell.dll", SetLastError=true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ExitWindowsEx([MarshalAs(UnmanagedType.U4)]uint dwFlags, [MarshalAs(UnmanagedType.U4)]uint dwReserved);
        enum ExitWindowsAction : uint
        {
            EWX_LOGOFF = 0,
            EWX_SHUTDOWN = 1,
            EWX_REBOOT = 2,
            EWX_FORCE = 4,
            EWX_POWEROFF = 8
        }
    //
        void rebootDevice()
        {
            ExitWindowsEx(ExitWindowsAction.EWX_REBOOT, 0);
        }
