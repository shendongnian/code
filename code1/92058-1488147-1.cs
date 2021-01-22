        public void downloadphoto(string struri, string strtitle, string placeid)
        {
            using (WebClient wc = new WebClient())
            {
                wcHandler handler = new wcHandler() { Strtitle = strtitle, Placeid = placeid };
                wc.DownloadDataCompleted += handler.wc_DownloadDataCompleted;
                wc.DownloadDataAsync(new Uri(struri));
            }
        }
        private class wcHandler
        {
            public string Strtitle { get; set; }
            public string Placeid { get; set; }
            public void wc_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
            {
                // Do Stuff
            }
        }
