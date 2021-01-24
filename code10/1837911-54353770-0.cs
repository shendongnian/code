    WebClient zaq;
    public void DownloadZaq()
        {
                zaq = new WebClient();
                zaq.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Zaq_DownloadProgressChanged);
                zaq.DownloadFileCompleted += new AsyncCompletedEventHandler(Zaq_DownloadFileCompleted);
                System.Threading.Tasks.Task.Run(() => // Workaround to allow Async call
                {
                    try
                    {
                         zaq.DownloadFileAsync(new Uri(http://example.com), @"c:\to\111.jpg");
                    }
                    catch (Exception ex)
                    {
                        zag.Dispose();
                    }
                });
               
            
        }
        public void Zaq_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("download completed");
            zag.Dispose();
        }
        public void Zaq_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
