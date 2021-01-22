        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWow64Process(
            [In] IntPtr hProcess,
            [Out] out bool wow64Process
        );
        public static string GetComputerArchitecture()
        {
            string MethodResult = "";
            try
            {
                string Architecture = "32bit";
                if ((Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1) || Environment.OSVersion.Version.Major >= 6)
                {
                    using (Process p = Process.GetCurrentProcess())
                    {
                        bool Is64Bit;
                        if (IsWow64Process(p.Handle, out Is64Bit))
                        {
                            if (Is64Bit)
                            {
                                Architecture = "64bit";
                            }
                        }
                        
                    }
                }
                MethodResult = Architecture;
            }
            catch //(Exception ex)
            {
                //ex.HandleException();
            }
            return MethodResult;
        }
