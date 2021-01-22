    [DllImport(DLLPath, CallingConvention = CallingConvention.Cdecl)]
    private extern static int AMRecoveryModeDeviceReboot(IntPtr device, byte[] paramByte, int u1, int u2, int u3)
    public static int AMRecoveryModeDevice(ref AMRecoveryDevice device, byte[] paramByte, int u1, int u2, int u3) {
        var ptr = Marshal.AllocHGlobal(Marshal.SizeOf(device));
        Marshal.StructureToPointer(device, ptr, false);
        int result = AMRecoveryModeDeviceReboot(ptr, paramByte, u1, u2, u3);
        device = (AMRecoveryDevice)Marshal.PtrToStructure(ptr, typeof(AMRecoveryDevice));
        Marshal.FreeHGlobal(ptr);
        return result;
    }
