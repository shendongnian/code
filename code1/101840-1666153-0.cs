	void MainPage_Loaded(object sender, RoutedEventArgs e)
	{
		DownloadXmlStateStream();
	}
	void DownloadXmlStateStream()
	{
		WebClient webClient = new WebClient();
		webClient.DownloadProgressChanged += (s, e) => {	
			lblProgress.Content = "Downloading " + e.ProgressPercentage + "%";
		}
		webClient.OpenReadCompleted += (s, e) => {
			if (e.Error != null)
			{
				lblProgress.Content = "Error: " + e.Error.Message;
			}
			else
			{
				XmlStateStream = e.Result;
				lblProgress.Content = "Done Loading";
			}			
		} 
		webClient.OpenReadAsync(new Uri("/trunk/internal/SilverLightInterface.ashx?xxid=XXX", UriKind.Relative));
	}
	
