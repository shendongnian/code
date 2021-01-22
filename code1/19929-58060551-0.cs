    using System;
    using System.IO;
    using System.Net;
    using System.ComponentModel;
    					
    public class Program
    {
        public static void Main()
        {
            new Program().Download("ftp://localhost/test.zip");
        }
        public void Download(string remoteUri)
        {
            string FilePath = Directory.GetCurrentDirectory() + "/tepdownload/" + Path.GetFileName(remoteUri); // path where download file to be saved, with filename, here I have taken file name from supplied remote url
            using (WebClient client = new WebClient())
            {
                try
                {
                    if (!Directory.Exists("tepdownload"))
                    {
                        Directory.CreateDirectory("tepdownload");
                    }
                    Uri uri = new Uri(remoteUri);
                    //password username of your file server eg. ftp username and password
                    client.Credentials = new NetworkCredential("username", "password");
                    //delegate method, which will be called after file download has been complete.
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(Extract);
                    //delegate method for progress notification handler.
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgessChanged);
                    // uri is the remote url where filed needs to be downloaded, and FilePath is the location where file to be saved
                    client.DownloadFileAsync(uri, FilePath);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public void Extract(object sender, AsyncCompletedEventArgs e)
        {
            Console.WriteLine("File has been downloaded.");
        }
        public void ProgessChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine($"Download status: {e.ProgressPercentage}%.");
        }
    }
