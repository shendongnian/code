    public void SetAlbumArt(string url, TagLib.File file)
    {            
        string path = string.Format(@"{0}temp\{1}.jpg", OutputPath, Guid.NewGuid().ToString());
        byte[] imageBytes;
        using (WebClient client = new WebClient())
        {
            imageBytes = client.DownloadData(url);
        }
    
        TagLib.Picture pic = new TagLib.Picture
        {
            Type = TagLib.PictureType.FrontCover,
            Description = "Cover",
            MimeType = System.Net.Mime.MediaTypeNames.Image.Jpeg,
            Data = imageBytes
                    
        };
        file.Tag.Pictures = new TagLib.IPicture[] { pic };
        file.Save();
    }
