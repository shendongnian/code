    private void DownloadProgress(DownloadOperation obj)
    {
        BackgroundDownloadProgress currentProgress = obj.Progress;
        double percent;
        if (currentProgress.TotalBytesToReceive > 0)
        {
            percent = currentProgress.BytesReceived * 100 / currentProgress.TotalBytesToReceive;
            Debug.WriteLine(percent);
            uCDownloadCard.DownloadCompletePercent = percent.ToString();
        }
    }
    
    UCDownloadCard uCDownloadCard;
    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        uCDownloadCard = new UCDownloadCard();
        MainPagePanel.Children.Add(uCDownloadCard);
    }
