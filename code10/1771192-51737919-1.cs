    Stopwatch timer = new Stopwatch();
    timer.Start();
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://example.com");
    
    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    {
        Console.WriteLine(timer.Elapsed);
        timer.Restart();
        using (Stream stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream))
        {
            Console.WriteLine(timer.Elapsed);
            timer.Stop();
        }
    }
