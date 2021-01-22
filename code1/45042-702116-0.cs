    var request = (HttpWebRequest)WebRequest.Create(@"http://www.youtube.com/");
    request.Referer = "http://www.youtube.com/"; // optional
    request.UserAgent =
        "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; WOW64; " +
        "Trident/4.0; SLCC1; .NET CLR 2.0.50727; Media Center PC 5.0; " +
        ".NET CLR 3.5.21022; .NET CLR 3.5.30729; .NET CLR 3.0.30618; " +
        "InfoPath.2; OfficeLiveConnector.1.3; OfficeLivePatch.0.0)";
    try
    {
        var response = (HttpWebResponse)request.GetResponse();
        using (var reader = new StreamReader(response.GetResponseStream()))
        {
            var html = reader.ReadToEnd();
        }
    }
    catch (WebException ex)
    {
        Debug.WriteLine(ex.Message);
    }
