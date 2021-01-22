    var request = (HttpWebRequest)WebRequest.Create("http://clients3.google.com/generate_204");
    request.UserAgent = "Android";
    request.KeepAlive = false;
    request.Timeout = 1500;
    
    using (var response = (HttpWebResponse)request.GetResponse())
    {
        if (response.ContentLength == 0 && response.StatusCode == HttpStatusCode.NoContent)
        {
        	//Connection to internet available
        }
        else
        {
        	//Connection to internet not available
        }
    }
