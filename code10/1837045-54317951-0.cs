    public ImageSource GenerateThumbImage(string url, long usecond)
    {   
        MediaMetadataRetriever retriever = new MediaMetadataRetriever();
        retriever.SetDataSource(url, new Dictionary<string, string>());
        Bitmap bitmap = retriever.GetFrameAtTime(usecond);
        if (bitmap != null)
        {
            MemoryStream stream = new MemoryStream();
            bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
            byte[] bitmapData = stream.ToArray();
            return ImageSource.FromStream(() => new MemoryStream(bitmapData));
        }
        return null;
    }
