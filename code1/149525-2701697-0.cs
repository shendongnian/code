    using (Stream file = File.Create("data.csv"))
    {
        request = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
        request.Timeout = 30000;
        using (var response = (HttpWebResponse)request.GetResponse())
        using (Stream input = response.GetResponseStream())
        {
            // Save the file using Jon Skeet's CopyStream method
            CopyStream(input, file);
        }
    }
