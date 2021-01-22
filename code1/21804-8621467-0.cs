        public static bool Is32bitProcess(Process proc) {
            if (!IsThis64bitProcess()) return true; // we're in 32bit mode, so all are 32bit
            foreach (ProcessModule module in proc.Modules) {
                try {
                    string fname = Path.GetFileName(module.FileName).ToLowerInvariant();
                    if (fname.Contains("wow64")) {
                        return true;
                    }
                } catch {
                    // wtf
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
