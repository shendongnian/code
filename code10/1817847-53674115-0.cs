    WebClient client = new WebClient();
    Uri address = new Uri(storageLocation);
    fileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + fileName;
    client.Headers.Add("Content-Type", "application/octet-stream");
    client.Headers.Add("Authorization", "Bearer " + credentials.TokenInternal);
    client.DownloadFileAsync(address, fileName);
    return client;
