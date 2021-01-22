        [DllImport("kernel32", SetLastError = true)]
        private static extern bool FreeLibrary(IntPtr hModule);
        public static void UnloadImportedDll(string DllPath)
        {
            foreach (System.Diagnostics.ProcessModule mod in System.Diagnostics.Process.GetCurrentProcess().Modules)
            {
                if (mod.FileName == DllPath)
                {
                    FreeLibrary(mod.BaseAddress);
                }
            }
        }
