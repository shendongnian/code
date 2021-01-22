        private void PrintFormPdfData(byte[] formPdfData)
        {
            string tempFile;
            tempFile = Path.GetTempFileName();
            using (FileStream fs = new FileStream(tempFile, FileMode.Create))
            {
                fs.Write(formPdfData, 0, formPdfData.Length);
                fs.Flush();
            }
            try
            {
                string gsArguments;
                string gsLocation;
                ProcessStartInfo gsProcessInfo;
                Process gsProcess;
                gsArguments = string.Format("-grey -noquery -printer \"HP LaserJet 5M\" \"{0}\"", tempFile);
                gsLocation = @"C:\Program Files\Ghostgum\gsview\gsprint.exe";
                gsProcessInfo = new ProcessStartInfo();
                gsProcessInfo.WindowStyle = ProcessWindowStyle.Hidden;
                gsProcessInfo.FileName = gsLocation;
                gsProcessInfo.Arguments = gsArguments;
                gsProcess = Process.Start(gsProcessInfo);
                gsProcess.WaitForExit();
            }
            finally
            {
                File.Delete(tempFile);
            }
        }
