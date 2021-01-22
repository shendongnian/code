        long totalRecieved = 0;
        DateTime lastProgressChange = DateTime.Now;
        Stack<int> timeSatck = new Stack<int>(5);
        Stack<long> byteSatck = new Stack<long>(5);
        using (WebClient c = new WebClient())
        {
            c.DownloadProgressChanged += delegate(object s, DownloadProgressChangedEventArgs args)
            {
                long bytes;
                if (totalRecieved == 0)
                {
                    totalRecieved = args.BytesReceived;
                    bytes = args.BytesReceived;
                }
                else
                {
                    bytes = args.BytesReceived - totalRecieved;
                }
                timeSatck.Push(DateTime.Now.Subtract(lastProgressChange).Seconds);
                byteSatck.Push(bytes);
                double r = timeSatck.Average() * ((args.TotalBytesToReceive - args.BytesReceived) / byteSatck.Average());
                this.textBox1.Text = (r / 60).ToString();
                totalRecieved = args.BytesReceived;
                lastProgressChange = DateTime.Now;
            };
            c.DownloadFileAsync(new Uri("http://www.visualsvn.com/files/VisualSVN-1.7.6.msi"), @"C:\SVN.msi");
        }
