    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        bool error = false;
        string url = txtUrl.Text;
        int counter = 1;
        btnStart.IsEnabled = false;
        using (var httpClient = new HttpClient())
        {
            while (!error)
            {
                lblProgress.Content = "Downloading page " + counter.ToString() + ":";
                string targetPath = $"c:\\temp\\downloads\\file{counter}.tmp";
                try
                {
                    using (var sourceStream = await httpClient.GetStreamAsync(url))
                    using (var targetStream = File.OpenWrite(targetPath))
                    {
                        await sourceStream.CopyToAsync(targetStream);
                    }
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
