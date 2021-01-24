    using (SKData origData = SKData.Create(imgStream)) // convert the stream into SKData
    using (SKImage srcImg = SKImage.FromEncodedData(origData))
        // srcImg now contains the original ColorSpace (e.g. CMYK)
    {
    	SKImageInfo info = new SKImageInfo(resizeWidth, resizeHeight,
    		SKImageInfo.PlatformColorType, SKAlphaType.Premul, SKColorSpace.CreateSrgb());
    	// this is the important part. set the destination ColorSpace as
    	// `SKColorSpace.CreateSrgb()`. Skia will then be able to automatically convert
    	// the original CMYK colorspace, to this new sRGB colorspace.
    
    	using (SKImage newImg = SKImage.Create(info)) // new image. ColorSpace set via `info`
    	{
    		srcImg.ScalePixels(newImg.PeekPixels(), SKFilterQuality.None);
    		// now when doing this resize, Skia knows the original ColorSpace, and the
    		// destination ColorSpace, and converts the colors from CMYK to sRGB.
    	}
    }
