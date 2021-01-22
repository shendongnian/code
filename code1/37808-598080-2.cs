    WebRequest r = WebRequest.Create("http://www.msn.com");
    WebResponse resp = r.GetResponse();
    using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
    {
        Console.WriteLine(sr.ReadToEnd());
    }
    Console.ReadKey();
