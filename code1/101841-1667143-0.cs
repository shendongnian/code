       void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
                WebClient webClient = new WebClient();
                webClient.DownloadProgressChanged +=
                        new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
                webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(webClient_OpenReadCompleted);
                webClient.OpenReadAsync(new Uri("/trunk/internal/SilverLightInterface.ashx?xxid=XXX", UriKind.Relative));
                LayoutRoot.IsHitTestVisible = false;
        }
        void webClient_DownloadProgressChanged(object sender, 
                DownloadProgressChangedEventArgs e) {
                lblProgress.Content = "Downloading " + e.ProgressPercentage + "%";
        }
        void webClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
                if (e.Error != null)
                {
                        lblProgress.Content = "Error: " + e.Error.Message;
                        return;
                }
                LayoutRoot.IsHitTestVisible = true;
                lblProgress.Content = "Done Loading.";
        }
