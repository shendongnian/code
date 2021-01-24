    public async Task<ImageSource> GetBytesFromImage(Bitmap bitmap)
     {
        ImageSource imgSource;
        using (var stream = new MemoryStream())
        {
            bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream); // You can change the compression asper your understanding
            imgSource=ImageSource.FromStream(stream);
        }
       return imgSource;
      }
