    using System.Diagnostics;
    
    class ProcessHandler {
        public static Process FindProcess( IntPtr yourHandle ) {
            foreach (Process p in Process.GetProcesses()) {
                if (p.Handle == yourHandle) {
                    return p;
                }
            }
            return null;
        }
    }
