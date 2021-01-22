	System.Drawing.Image NewImage = null;
	System.Drawing.Image FullsizeImage = null;
	try
	{
		FullsizeImage = System.Drawing.Image.FromFile(OriginalFile);
         [... snip ... ]
		NewImage = FullsizeImage.GetThumbnailImage(NewWidth, NewHeight, null, IntPtr.Zero);
		// Clear handle to original file so that we can overwrite it if necessary
		FullsizeImage.Dispose();
		// Save resized picture
		NewImage.Save(NewFile);
	}
	finally
	{
		if (FullsizeImage != null)
			FullsizeImage.Dispose();
		if (NewImage != null)
			NewImage.Dispose();
	}
