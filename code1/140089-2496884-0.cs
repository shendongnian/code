        public static void DownLoadFileInBackground(string address)
        {
            WebClient client = new WebClient();
            Uri uri = new Uri(address);
            client.DownloadFileCompleted += (sender,e)=>
                                            {
                                                //inspect e here:
                                                //e.Error
                                            };
            client.DownloadProgressChanged += (sender,e)=>
                                              {
                                                  //e.ProgressPercentage
                                              };
            client.DownloadFileAsync(uri, "blabla");
        }
