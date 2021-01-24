    public enum DEVICE_POWER_STATE {
        PowerDeviceUnspecified,
        PowerDeviceD0,
        PowerDeviceD1,
        PowerDeviceD2,
        PowerDeviceD3,
        PowerDeviceMaximum
    }
    public enum SYSTEM_POWER_STATE {
        PowerSystemUnspecified,
        PowerSystemWorking,
        PowerSystemSleeping1,
        PowerSystemSleeping2,
        PowerSystemSleeping3,
        PowerSystemHibernate,
        PowerSystemShutdown,
        PowerSystemMaximum
    }
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SP_DEVINFO_DATA {
        public UInt32 cbSize;
        public Guid ClassGuid;
        public UInt32 DevInst;
        public IntPtr Reserved;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct CM_POWER_DATA {
        public uint PD_Size;
        public DEVICE_POWER_STATE PD_MostRecentPowerState;
        public uint PD_Capabilities;
        public uint PD_D1Latency;
        public uint PD_D2Latency;
        public uint PD_D3Latency;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
        public DEVICE_POWER_STATE[] PD_PowerStateMapping;
        public SYSTEM_POWER_STATE PD_DeepestSystemWake;
    }
