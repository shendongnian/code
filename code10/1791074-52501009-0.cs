     public aysnc Task DownloadFromRepo(String fileName)
     {
        ...
        using (WebClient FileClient = new WebClient())
        {
            ...
            await FileClient.DownloadFileTaskAsync(new System.Uri(RepoDir + fileName), 
    curFilePath);
        }
    }
