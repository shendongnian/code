    try {
        response = (HttpWebResponse)WebRequest.GetResponse();
        // etc
    }
    catch(WebException ex)
    {
        var webResponseCode = (ex.Response as HttpWebResponse)?.StatusCode;
        if (webResponseCode == HttpStatusCode.NotFound) {
            var resp = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
        } 
    }
    
