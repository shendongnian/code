    public void AddMp3Tags()
    {
        TagLib.Id3v2.Tag.DefaultVersion = 3;
        TagLib.Id3v2.Tag.ForceDefaultVersion = true;
        TagLib.File file = TagLib.File.Create(OutputPath + OutputName + ".mp3");
        SetAlbumArt(Art, file);
        file.Tag.Title = SongTitle;
        file.Tag.Performers = Artists.Split(',');
        file.Tag.Album = Album;           
        file.Tag.Track = (uint)TrackNumber;
        file.Tag.Year = (uint)Convert.ToInt32(Regex.Match(Year, @"(\d)(\d)(\d)(\d)").Value);
        file.RemoveTags(file.TagTypes & ~file.TagTypesOnDisk);
        file.Save();
    }
    
    public void SetAlbumArt(string url, TagLib.File file)
    {            
        string path = string.Format(@"{0}temp\{1}.jpg", OutputPath, Guid.NewGuid().ToString());
        byte[] imageBytes;
        using (WebClient client = new WebClient())
        {
            imageBytes = client.DownloadData(url);
        }
    
        TagLib.Id3v2.AttachedPictureFrame cover = new TagLib.Id3v2.AttachedPictureFrame
        {
            Type = TagLib.PictureType.FrontCover,
            Description = "Cover",
            MimeType = System.Net.Mime.MediaTypeNames.Image.Jpeg,
            Data = imageBytes,
            TextEncoding = TagLib.StringType.UTF16
                    
                    
        };
        file.Tag.Pictures = new TagLib.IPicture[] { cover };
    }
