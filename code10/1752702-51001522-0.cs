    private static void wc_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
            {
                String ZipPath = Environment.CurrentDirectory + "\\spacelightzipped.zip";
                String extractPath = Environment.CurrentDirectory;
                ZipFile.ExtractToDirectory(ZipPath, extractPath);
    
                System.Diagnostics.Process proc = new System.Diagnostics.Process
                  {
                     EnableRaisingEvents = false
                  };
                 proc.StartInfo.FileName = Environment.CurrentDirectory + "\\SpaceLightApp.exe";
                 proc.Start();
            }
