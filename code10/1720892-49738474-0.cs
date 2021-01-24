    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Net;
    using System.Threading;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
                new Thread(() =>
                {
                    var client = new WebClient();
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
                    client.DownloadFileAsync(new Uri("https://speed.hetzner.de/100MB.bin"), @"C:\Users\Luke\Desktop\100mb.bin");
                }).Start();
            }
            private static void webClient_DownloadFileCompleted(object s, AsyncCompletedEventArgs e)
            {
                Debug.WriteLine("Download completed!");
            }
            private static void webClient_DownloadProgressChanged(object s, DownloadProgressChangedEventArgs e)
            {
                Debug.WriteLine(e.BytesReceived);
            }
        }
    }
