        private void button2_Click(object sender, RoutedEventArgs e)
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += HttpsCompleted;
            wc.DownloadStringAsync(new Uri("https://domain/path/file.xml"));
        }
        private void HttpsCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                XDocument xdoc = XDocument.Parse(e.Result, LoadOptions.None);
                this.textBox1.Text = xdoc.FirstNode.ToString();
            }
        }
