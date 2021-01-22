    using (var request = System.Net.HttpWebRequest.Create(
        "http://tempuri.org/pathToFile"))
    {
        request.Method = "HEAD";
        using (var response = request.GetResponse())
        {
            switch (response.ContentType)
            {
                case "text/xml":
                    // ...
                    break;
                case "text/html":
                    // ...
                    break;
            }
        }
    }
