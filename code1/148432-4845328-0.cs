    static ManualResetEvent done = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            client.UploadProgressChanged += new UploadProgressChangedEventHandler(client_UploadProgressChanged);
            client.UploadFileCompleted += new UploadFileCompletedEventHandler(client_UploadFileCompleted);
            client.UploadFileAsync(new Uri("http://localhost/upload"), "C:\\test.zip");
            done.WaitOne();
            Console.WriteLine("Done");
        }
        static void client_UploadFileCompleted(object sender, UploadFileCompletedEventArgs e)
        {
            done.Set();
        }
        static void client_UploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            Console.Write("\rUploading: {0}%  {1} of {2}", e.ProgressPercentage, e.BytesSent, e.TotalBytesToSend);
        }
