    public void addImageComment(string imageFlePath, string comments)
        {
            string jpegDirectory = Path.GetDirectoryName(imageFlePath);
            string jpegFileName = Path.GetFileNameWithoutExtension(imageFlePath);
    
            BitmapDecoder decoder = null;
            BitmapFrame bitmapFrame = null;
            BitmapMetadata metadata = null;
            FileInfo originalImage = new FileInfo(imageFlePath);
    
            if (File.Exists(imageFlePath))
            {
                // load the jpg file with a JpegBitmapDecoder    
                using (Stream jpegStreamIn = File.Open(imageFlePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    decoder = new JpegBitmapDecoder(jpegStreamIn, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                }
    
                bitmapFrame = decoder.Frames[0];
                metadata = (BitmapMetadata)bitmapFrame.Metadata;
    
                if (bitmapFrame != null)
                {
                    BitmapMetadata metaData = (BitmapMetadata)bitmapFrame.Metadata.Clone();
    
                    if (metaData != null)
                    {
                        // modify the metadata   
                        metaData.SetQuery("/app1/ifd/exif:{uint=40092}", comments);
    
                        // get an encoder to create a new jpg file with the new metadata.      
                        JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(bitmapFrame, bitmapFrame.Thumbnail, metaData, bitmapFrame.ColorContexts));
                        //string jpegNewFileName = Path.Combine(jpegDirectory, "JpegTemp.jpg");
    
                        // Delete the original
                        originalImage.Delete();
    
                        // Save the new image 
                        using (Stream jpegStreamOut = File.Open(imageFlePath, FileMode.CreateNew, FileAccess.ReadWrite))
                        {
                            encoder.Save(jpegStreamOut);
                        }
                    }
                }
            }
        }
