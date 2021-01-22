    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
    request.Timeout = 20000;
    using (WebResponse response = request.GetResponse())
    {
        using (var stream = response.GetResponseStream())
        {
            using (var reader = new StreamReader(stream))
            {
                var result = reader.ReadToEnd();
                // Do something with result
            }
        }
    }
