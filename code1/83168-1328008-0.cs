    // Load as Bitmap
	using (Bitmap bmp = new Bitmap(file))
	{
	    // Get pages in bitmap
	    int frames = bmp.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);
	    bmp.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, tiffpage);
	    if (bmp.PixelFormat != PixelFormat.Format1bppIndexed)
	    {
	        using (Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height))
	        {
	            bmp2.Palette = bmp.Palette;
	            bmp2.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);
	            // create graphics object for new bitmap
	            using (Graphics g = Graphics.FromImage(bmp2))
	            {
	                // copy current page into new bitmap
	                g.DrawImageUnscaled(bmp, 0, 0);
	
									// do whatever you migth to do
	                ...
	                
	            }
	        }
	    }
	}
