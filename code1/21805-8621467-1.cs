        public static bool Is32bitProcess(Process proc) {
            if (!IsThis64bitProcess()) return true; // We're in 32-bit mode, so all are 32-bit.
            foreach (ProcessModule module in proc.Modules) {
                try {
                    string fname = Path.GetFileName(module.FileName).ToLowerInvariant();
                    if (fname.Contains("wow64")) {
                        return true;
                    }
                } catch {
                    // What on earth is going on here?
                }
            }
            return false;
        }
        public static bool Is64bitProcess(Process proc) {
            return !Is32bitProcess(proc);
        }
        public static bool IsThis64bitProcess() {
            return (IntPtr.Size == 8);
        }
