    Console.WriteLine("Downloading...");
    client.DownloadFileAsync(new Uri(file.Value), filePath);
    while (client.IsBusy)
    {
        // run some stuff like checking download progress etc
    }
    Console.WriteLine("Done. {0}", filePath);
