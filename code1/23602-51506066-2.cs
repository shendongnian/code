        // Sample fileName = System.Environment.GetFolderPath(
        // System.Environment.SpecialFolder.CommonApplicationData)
        //  + @"\MyCompany\MyProject\TestPrint.pdf"
        private void SendPrintJob(string fileName)
        {
            try
            {
               // Start by finding Acrobat from the Registry.
               // This supposedly gets whichever you have of free or paid
                string processFilename = Microsoft.Win32.Registry.LocalMachine
                     .OpenSubKey("Software")
                     .OpenSubKey("Microsoft")
                     .OpenSubKey("Windows")
                     .OpenSubKey("CurrentVersion")
                     .OpenSubKey("App Paths")
                     .OpenSubKey("AcroRd32.exe")
                     .GetValue(String.Empty).ToString();
                ProcessStartInfo info = new ProcessStartInfo();
                info.Verb = "print";
                info.FileName = processFilename;
                info.Arguments = String.Format("/p /h {0}", fileName);
                info.CreateNoWindow = true;
                info.WindowStyle = ProcessWindowStyle.Hidden;
                info.UseShellExecute = false;
                Process p = new Process();
                p.StartInfo = info;
                p.Start();
                p.WaitForInputIdle();
                // Recommended to add a time-out feature. Mine is coded here.
            }
            catch (Exception e)
            {
                Console.WriteLine("Error sending print job. " + e.Message);
            }
