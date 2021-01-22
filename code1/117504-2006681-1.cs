    foreach (var url in File.ReadAllLines("urls.txt"))
    {
        var client = new WebClient();
        client.DownloadStringCompleted += (sender, e) => 
        {
            if (e.Error == null)
            {
                // e.Result will contain the downloaded HTML
            }
            else
            {
                // some error occurred: analyze e.Error property
            }
        };
        client.DownloadStringAsync(new Uri(url));
    }
