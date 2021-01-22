        // create a new instance of WebClient
        WebClient client = new WebClient();
 
        // set the user agent to IE6
        client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.0.3705;)");
        try
        {
            // actually execute the GET request
            string ret = client.DownloadString("http://www.google.com/");
 
            // ret now contains the contents of the webpage
            Console.WriteLine("First 256 bytes of response: " + ret.Substring(0,265));
        }
        catch (WebException we)
        {
            // WebException.Status holds useful information
            Console.WriteLine(we.Message + "\n" + we.Status.ToString());
        }
        catch (NotSupportedException ne)
        {
            // other errors
            Console.WriteLine(ne.Message);
        }
