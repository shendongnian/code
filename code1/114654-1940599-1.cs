    // This allows us to resize the image. It prevents skewed images and 
    // also vertically long images caused by trying to maintain the aspect 
    // ratio on images who's height is larger than their width
    public void ResizeImage(string OriginalFile, string NewFile, int NewWidth, int MaxHeight, bool OnlyResizeIfWider)
    {
    	System.Drawing.Image FullsizeImage = System.Drawing.Image.FromFile(OriginalFile);
    
    	// Prevent using images internal thumbnail
    	FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
    	FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
    
    	if (OnlyResizeIfWider)
    	{
    		if (FullsizeImage.Width <= NewWidth)
    		{
    			NewWidth = FullsizeImage.Width;
    		}
    	}
    
    	int NewHeight = FullsizeImage.Height * NewWidth / FullsizeImage.Width;
    	if (NewHeight > MaxHeight)
    	{
    		// Resize with height instead
    		NewWidth = FullsizeImage.Width * MaxHeight / FullsizeImage.Height;
    		NewHeight = MaxHeight;
    	}
    
    	System.Drawing.Image NewImage = FullsizeImage.GetThumbnailImage(NewWidth, NewHeight, null, IntPtr.Zero);
    
    	// Clear handle to original file so that we can overwrite it if necessary
    	FullsizeImage.Dispose();
    
    	// Save resized picture
    	NewImage.Save(NewFile);
    }
