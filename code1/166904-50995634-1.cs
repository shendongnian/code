    private MemoryStream GetStreamFromUrl(string url)
    {
        byte[] imageData = null;
        MemoryStream ms;
        ms = null;
        try
        {
            using (var wc = new System.Net.WebClient())
            {
                imageData = wc.DownloadData(url);
            }
            ms = new MemoryStream(imageData);
        }
        catch (Exception ex)
        {
            //forbidden, proxy issues, file not found (404) etc
        }
        return ms;
    }
