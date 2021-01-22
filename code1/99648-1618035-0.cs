    public static MetaData CreateMetaDataFrom(IEnumerable<TextFrame> textFrames)
    {
        return new MetaData()
        {
            metaData.AlbumArtist = textFrames.Where(frame => frame.Descriptor.ID = "TPE1").SingleOrDefault().Content,
            metaData.AlbumTitle = textFrames.Where(frame => frame.Descriptor.ID = "TALB").SingleOrDefault().Content, 
            metaData.SongTitle = textFrames.Where(frame => frame.Descriptor.ID = "TIT2").SingleOrDefault().Content;
            metaData.Year = textFrames.Where(frame => frame.Descriptor.ID = "TYER").SingleOrDefault().Content;
        };
    }
