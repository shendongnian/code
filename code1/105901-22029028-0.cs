    public static Image SetImageComment(Image image, string comment) {
      using (var memStream = new MemoryStream()) {
        image.Save(memStream, ImageFormat.Jpeg);
        memStream.Position = 0;
        var decoder = new JpegBitmapDecoder(memStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
        BitmapMetadata metadata;
        if (decoder.Metadata == null) {
          metadata = new BitmapMetadata("jpg");
        } else {
          metadata = decoder.Metadata;
        }
        metadata.Comment = comment;
        var bitmapFrame = decoder.Frames[0];
        BitmapEncoder encoder = new JpegBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(bitmapFrame, bitmapFrame.Thumbnail, metadata, bitmapFrame.ColorContexts));
        var imageStream = new MemoryStream();
        encoder.Save(imageStream);
        imageStream.Position = 0;
        image.Dispose();
        image = null;
        return Image.FromStream(imageStream);
      }
    }
