    private void btn1_Click(object sender, RoutedEventArgs e)
        {
            string url = "http://www.nu.nl/feeds/rss/algemeen.rss";
            this.client.DownloadStringAsync(new Uri(url, UriKind.Absolute));
        }
        private void ClientDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
			Stream s = e.Result;
			StreamReader strReader = new StreamReader(s);
			string webContent = strReader.ReadToEnd();
			s.Close();
            this.txbSummery.Text =webContent;
            
        }
