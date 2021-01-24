    private void DownloadFileCallback(object sender, AsyncCompletedEventArgs e)  {
        if (File.Exists(filename)) {
            Process process = Process.Start(filename);
            process.WaitForExit();
        }
    }
