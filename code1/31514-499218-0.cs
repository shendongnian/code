    private Image GetImage(string filePath)
    {
        WebClient l_WebClient = new WebClient();
        byte[] l_imageBytes = l_WebClient.DownloadData(filePath);
        MemoryStream l_stream = new MemoryStream(l_imageBytes);
        return Image.FromStream(l_stream);
    }
