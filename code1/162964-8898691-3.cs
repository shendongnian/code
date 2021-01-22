    public static class MutexExtensionMethods
    {
        public static bool TryQuery(this Mutex m, out int currentCount, out bool ownedByCaller, out bool abandonedState)
        {
            currentCount = -1;
            ownedByCaller = abandonedState = false;
            try
            {
                var handle = m.SafeWaitHandle;
                if (handle != null)
                {
                    var h = handle.DangerousGetHandle();
                    MutantBasicInformation mbi;
                    int retLength;
                    var ntStatus = NtQueryMutant(
                        h,
                        MutantInformationClass.MutantBasicInformation,
                        out mbi, 
                        Marshal.SizeOf(typeof(MutantBasicInformation)),
                        out retLength);
                    GC.KeepAlive(handle); // Prevent "handle" from being collected before NtQueryMutant returns
                    if (ntStatus == 0)
                    {
                        currentCount   = mbi.CurrentCount;
                        ownedByCaller  = mbi.OwnedByCaller;
                        abandonedState = mbi.AbandonedState;
                        return true;
                    }
                }
            }
            catch
            {
            }
            return false;
        }
        #region NTDLL.DLL
        [DllImport("ntdll.dll")]
        public static extern uint NtQueryMutant(
            [In] IntPtr MutantHandle,
            [In] MutantInformationClass MutantInformationClass,
            [Out] out MutantBasicInformation MutantInformation,
            [In] int MutantInformationLength,
            [Out] [Optional] out int ReturnLength
            );
        public enum MutantInformationClass : int
        {
            MutantBasicInformation
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct MutantBasicInformation
        {
            public int CurrentCount;
            [MarshalAs(UnmanagedType.U1)]
            public bool OwnedByCaller;
            [MarshalAs(UnmanagedType.U1)]
            public bool AbandonedState;
        }
        #endregion
    }
