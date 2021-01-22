    [DllImport(DLLPath, CallingConvention = CallingConvention.Cdecl)]
    unsafe public extern static int AMRecoveryModeDeviceReboot(
        ref AMRecoveryDevice device, 
        byte[] paramByte, 
        int u1, 
        int u2, 
        int u3)
