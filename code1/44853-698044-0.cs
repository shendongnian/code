    string result;
    using (WebResponse response = request.GetResponse())
    {
        using (var sr = new StreamReader(response.GetResponseStream()))
        {
            result = sr.ReadToEnd();
        }
    }
