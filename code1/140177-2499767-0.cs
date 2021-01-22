    string response;
    using (var client = new WebClient()) {
        byte[] bytes = client.DownloadData(url);
        response = Encoding.UTF8.GetString(bytes);
    }
