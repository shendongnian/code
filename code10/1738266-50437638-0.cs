    public void SetAlbumArt(string url, TagLib.File file)
    {     
        string path = string.Format(@"{0}temp\{1}.jpg", OutputPath, Guid.NewGuid().ToString());
        using (WebClient client = new WebClient())
        {
    
            client.DownloadFile(new Uri(url), path);
        }
    
        file.Tag.Pictures = new TagLib.IPicture[]
        {
            new TagLib.Picture(new TagLib.ByteVector((byte[])new System.Drawing.ImageConverter().ConvertTo(System.Drawing.Image.FromFile(path), typeof(byte[]))))
            {
                Type = TagLib.PictureType.FrontCover,
                Description = "Cover",
                MimeType = System.Net.Mime.MediaTypeNames.Image.Jpeg
            }
        };
    
        file.Save();
    }
