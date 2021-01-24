    public void SaveImagesAsGif(Stream stream, ICollection<Bitmap> images, float fps, bool loop)
        {
            if (images == null || images.ToArray().Length == 0)
            {
                throw new ArgumentException("There are no images to add to animation");
            }
            int loopCount = 0;
            if (!loop)
            {
                loopCount = 1;
            }
            using (var encoder = new BumpKit.GifEncoder(stream, null, null, loopCount))
            {
                //calling initheader function
                //TODO: Change YOURGIFWIDTHHERE and YOURGIFHEIGHTHERE to desired width and height for gif
                encoder.InitHeader(stream, YOURGIFWIDTHHERE, YOURGIFHEIGHTHERE);
                foreach (Bitmap bitmap in images)
                {
                    encoder.AddFrame(bitmap, 0, 0, TimeSpan.FromSeconds(1 / fps));
                }
            }
            stream.Position = 0;
        }
