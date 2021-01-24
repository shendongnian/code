    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        bool error = false;
        string url = txtUrl.Text;
        int counter = 1;
        btnStart.IsEnabled = false;
        using (var webClient = new WebClient())
        {
            while (!error)
            {
                lblProgress.Content = "Downloading page " + counter.ToString() + ":";
                string targetPath = $"c:\\temp\\downloads\\file{counter}.tmp";
                try
                {
                    await webClient.DownloadFileTaskAsync(url, targetPath);
                }
                catch
                {
                    error = true;
                }
                counter++;
            }
        }
        btnStart.IsEnabled = true;
    }
