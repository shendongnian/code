    try
    {
        string webAddr = url;
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
        httpWebRequest.ContentType = "text/html; charset=utf-8";
        httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:58.0) Gecko/20100101 Firefox/58.0";
        httpWebRequest.AllowAutoRedirect = true;
        httpWebRequest.Method = "GET";
        httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream(), Encoding.UTF8))
        {
            var responseText = streamReader.ReadToEnd();
            doc.LoadHtml(responseText);
        }
    }
    catch (WebException ex)
    {
        Console.WriteLine(ex.Message);
    }
