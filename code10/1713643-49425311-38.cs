    static class NativeMethods {
        public static ulong GetThreadCycles() {
            ulong cycles;
            if (!QueryThreadCycleTime(PseudoHandle, out cycles))
                throw new System.ComponentModel.Win32Exception();
            return cycles;
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool QueryThreadCycleTime(IntPtr hThread, out ulong cycles);
        private static readonly IntPtr PseudoHandle = (IntPtr)(-2);
    }
