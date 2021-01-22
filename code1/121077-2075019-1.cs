        public class Threader
            {
                MyDownloader md;
                public void UserClicksDownload()
                {
                    md = new MyDownloader();
                    Thread t = new Thread(md.DownloadStuff);            
                    t.Start();
        
                    Thread.Sleep(100);
                }
      
                public void UserClicksStop()
                {
                    t.Abort();
                    t = null;
                    md.StopDownloading();
                }
            }
        
            public class MyDownloader 
            {
                public void DownloadStuff()
                {
                    while (true)
                    {
                        Console.WriteLine("downloading stuff!");
                    }
                }
        
                public void StopDownloading()
                {
                    Console.WriteLine("Tidy up you downloads here");
                }
            }
