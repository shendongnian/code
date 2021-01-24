    class Program
    {
        static void Main(string[] args)
        {
            var processes = Process
                .GetProcesses()
                .Where(a => a.IsNetflix());
                       
            Console.ReadKey();
        }
    }
    static class Extensions
    {
        public static bool IsNetflix(this Process process)
        {
            if (process.ProcessName.IndexOf("WWAHost", StringComparison.OrdinalIgnoreCase) == -1) return false;
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher($"SELECT CommandLine FROM Win32_Process WHERE ProcessId = {process.Id}"))
            using (ManagementObjectCollection objects = searcher.Get())
            {
                var managementObject = objects
                    .Cast<ManagementBaseObject>()
                    .SingleOrDefault();
                if (managementObject == null) return false;
                return managementObject["CommandLine"].ToString().IndexOf("netflix", StringComparison.OrdinalIgnoreCase) > -1;
            }
        }
    }
