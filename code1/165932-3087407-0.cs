    private void RemoveIfContains(TiffTagCollection tags, int tagID)
    {
        TiffTag tag = tags.LookupTag(tagID);
        if (tag != null)
           tags.Remove(tag);
    }
    public void SetTiffResolution(string tiffin, string tiffout, int page, double resolution ) {
        if (tiffin == tiffout)
           throw new ArgumentException(tiffout, "output path must be different from input path");
        TiffFile tf = new TiffFile();
        using (FileStream stm = new FileStream(tiffin, FileMode.Open, FileAccess.Read, FileShare.Read)) {
            tf.Read(stm);
            TiffDirectory image = tf.Images[page];
            RemoveIfContains(image.Tags, TiffTagID.ResolutionX);
            RemoveIfContains(image.Tags, TiffTagID.ResolutionY);
            RemoveIfContains(image.Tags, TiffTagID.ResolutionUnit);
            image.Tags.Add(new TiffTag(TiffTagID.ResolutionX, resolution);
            image.Tags.Add(new TiffTag(TiffTagID.ResolutionY, resolution);
            image.Tags.Add(new TiffTag(TiffTagID.ResolutionUnit, 2)); // 2 == dots per INCH
            tf.Save(tiffout);
        }
    }           
 
