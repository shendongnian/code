    public String DownloadImage(Uri URL)
    {
        WebClient webClient = new WebClient();
        string folderPath   = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Images", "temp");
        string fileName     = URL.ToString().Split('/').Last();
        string filePath     = System.IO.Path.Combine(folderPath, fileName);
        webClient.DownloadDataCompleted += (s, e) =>
        {
            Directory.CreateDirectory(folderPath);
            File.WriteAllBytes(filePath, e.Result);
        };
        webClient.DownloadDataAsync(URL);
        return filePath;
    }
