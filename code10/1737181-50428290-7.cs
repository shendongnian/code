    using (SKCodec codec = SKCodec.Create(imgStream)) // create a codec with the imgStream
    {
    	SKImageInfo info = new SKImageInfo(codec.Info.Width, codec.Info.Height,
    		SKImageInfo.PlatformColorType, SKAlphaType.Premul, SKColorSpace.CreateSrgb());
    	// set the destination ColorSpace via SKColorSpace.CreateSrgb()
    
    	SKBitmap srcImg = SKBitmap.Decode(codec, info);
    	// Skia creates a new bitmap, converting the codec ColorSpace (e.g. CMYK) to the
    	// destination ColorSpace (sRGB)
    }
