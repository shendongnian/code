    HttpWebRequest req;
    HttpWebResponse resp;
    try
    {
        req = (HttpWebRequest)WebRequest.Create("http://www.google.com");
        resp = (HttpWebResponse)req.GetResponse();
        if(resp.StatusCode.ToString().Equals("OK"))
        {
            Console.WriteLine("its connected.");
        }
        else
        {
            Console.WriteLine("its not connected.");
        }
    }
    catch(Exception exc)
    {
        Console.WriteLine("its not connected.");
    }
