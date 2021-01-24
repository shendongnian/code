            WebClient client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)");
            client.Headers.Add("Content-Type", "application / zip, application / octet - stream");
            client.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
            client.Headers.Add("Referer", "http://whatevs");
            client.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            String nikeStuff = client.DownloadString("https://www.nike.com/launch/?s=upcoming");
            Console.WriteLine(nikeStuff);
            Console.Read();
