    public static class ProcessManager
    {
        [Flags]
        public enum ThreadAccess : int
        {
            TERMINATE = (0x0001),
            SUSPEND_RESUME = (0x0002),
            GET_CONTEXT = (0x0008),
            SET_CONTEXT = (0x0010),
            SET_INFORMATION = (0x0020),
            QUERY_INFORMATION = (0x0040),
            SET_THREAD_TOKEN = (0x0080),
            IMPERSONATE = (0x0100),
            DIRECT_IMPERSONATION = (0x0200)
        }
        [DllImport("kernel32.dll")]
        static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);
        [DllImport("kernel32.dll")]
        static extern uint SuspendThread(IntPtr hThread);
        [DllImport("kernel32.dll")]
        static extern int ResumeThread(IntPtr hThread);
        [DllImport("kernel32.dll")]
        static extern int CloseHandle(IntPtr hThread);
        public static void ThrottleProcess(int processId, double limit)
        {
            var process = Process.GetProcessById(processId);
            var processName = process.ProcessName;
            var p = new PerformanceCounter("Process", "% Processor Time", processName);
            while (true)
            {
                var interval = 100;
                Thread.Sleep(interval);
                
                var currentUsage = p.NextValue() / Environment.ProcessorCount;
                if (currentUsage < limit) continue;
                var suspensionTime = (currentUsage-limit) / currentUsage * interval;
                SuspendProcess(processId);
                Thread.Sleep((int)suspensionTime);
                ResumeProcess(processId);
            }
        }
        private static void SuspendProcess(int pid)
        {
            var process = Process.GetProcessById(pid);
            if (process.ProcessName == string.Empty)
                return;
            foreach (ProcessThread pT in process.Threads)
            {
                IntPtr pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)pT.Id);
                if (pOpenThread == IntPtr.Zero)
                {
                    continue;
                }
                SuspendThread(pOpenThread);
                CloseHandle(pOpenThread);
            }
        }
        private static void ResumeProcess(int pid)
        {
            var process = Process.GetProcessById(pid);
            if (process.ProcessName == string.Empty)
                return;
            foreach (ProcessThread pT in process.Threads)
            {
                IntPtr pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)pT.Id);
                if (pOpenThread == IntPtr.Zero)
                {
                    continue;
                }
                var suspendCount = 0;
                do
                {
                    suspendCount = ResumeThread(pOpenThread);
                } while (suspendCount > 0);
                CloseHandle(pOpenThread);
            }
        }
    }
