        private static void Main(string[] args)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            startInfo.FileName = @"C:\Program Files (x86)\Microsoft SDKs\Azure\Storage Emulator\AzureStorageEmulator.exe";
            startInfo.Arguments = "start";
            process.StartInfo = startInfo;
            process.Start();
            
            //Wait for finished initialization
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(10));
            
            //After initialization, close the Emulator
            Process[] processes = Process.GetProcessesByName("AzureStorageEmulator");
    
            foreach (var p in processes)
            {
                p.Kill();
            }
    
        }
