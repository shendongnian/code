    System.Net.WebRequest req = System.Net.HttpWebRequest.Create("http://stackoverflow.com/robots.txt");
    req.Method = "HEAD";
    System.Net.WebResponse resp = req.GetResponse();
    int ContentLength;
    if(int.TryParse(resp.Headers.Get("Content-Length"), out ContentLength))
    { 
        //Do something useful with ContentLength here 
    }
