    public static Icon ConvertImagesToIco(Image[] images)
    {
        Int32 imgCount = images.Length;
        if (imgCount > 0xFFFF)
            throw new ArgumentException("Too many images!", "images");
        using (MemoryStream ms = new MemoryStream())
        using (BinaryWriter iconWriter = new BinaryWriter(ms))
        {
            Int32 offset = 0;
            Byte[][] frameBytes = new Byte[imgCount][];
            // 0-1 reserved, 0
            iconWriter.Write((Byte)0);
            iconWriter.Write((Byte)0);
            // 2-3 image type, 1 = icon, 2 = cursor
            iconWriter.Write((Int16)1);
            // 4-5 number of images
            iconWriter.Write((Int16)imgCount);
            offset += 6 + (16 * imgCount);
            for (Int32 i = 0; i < imgCount; ++i)
            {
                Image curFrame = images[i];
                Int32 width = curFrame.Width;
                Int32 height = curFrame.Height;
                if (width > 256 || height > 256)
                    throw new ArgumentException("Image too large!", "images");
                Int32 bpp;
                Byte[] frameData;
                using (MemoryStream pngMs = new MemoryStream())
                {
                    curFrame.Save(pngMs, ImageFormat.Png);
                    frameData = pngMs.ToArray();
                }
                // Get the colour depth to save in the icon info. This needs to be
                // fetched explicitly, since png does not support certain types
                // like 16bpp, so it will convert to the nearest valid on save.
                Byte colDepth = frameData[24];
                Byte colType = frameData[25];
                // I think .Net saving only supports 2, 3 and 6 anyway.
                switch (colType)
                {
                    case 2: bpp = 3 * colDepth; break; // RGB
                    case 6: bpp = 4 * colDepth; break; // ARGB
                    default: bpp = colDepth; break; // Indexed & greyscale
                }
                frameBytes[i] = frameData;
                Int32 imageLen = frameData.Length;
                // image entry
                // 0 image width
                iconWriter.Write((Byte)(width == 256 ? 0 : width)); // is 0 for "256"
                // 1 image height
                iconWriter.Write((Byte)(height == 256 ? 0 : height));
                // 2 number of colors
                iconWriter.Write((Byte)0);
                // 3 reserved
                iconWriter.Write((Byte)0);
                // 4-5 color planes
                iconWriter.Write((Int16)0);
                // 6-7 bits per pixel
                iconWriter.Write((Int16)bpp);
                // 8-11 size of image data
                iconWriter.Write(imageLen);
                // 12-15 offset of image data
                iconWriter.Write(offset);
                offset += imageLen;
            }
            for (Int32 i = 0; i < imgCount; i++)
            {
                // write image data
                // png data must contain the whole png data file
                iconWriter.Write(frameBytes[i]);
            }
            iconWriter.Flush();
            ms.Position = 0;
            return new Icon(ms);
        }
    }
