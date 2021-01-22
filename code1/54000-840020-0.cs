    BitmapData bmpData = bitmap.LockBits(pixelRect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
    
    unsafe
    {
    	byte* bytes = (byte*)bmpData.Scan0;
    	for (int row = 0; row < pixelRect.Height; row++)
    	{
    		for (int col = 0; col < pixelRect.Width * 4; ) // * 4: 4 bytes per pixel 
    		{
    			bytes[row * bmpData.Stride + col++] = blue;
    			bytes[row * bmpData.Stride + col++] = green;
    			bytes[row * bmpData.Stride + col++] = red;
    			bytes[row * bmpData.Stride + col++] = alpha;
    		}
    	}
    }
    
    // Unlock the bits.
    bitmap.UnlockBits(bmpData);
