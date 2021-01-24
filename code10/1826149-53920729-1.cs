    Bitmap bmp = new Bitmap(); // your bitmap contain a face
    Mat mat = GetMatFromSDImage(bmp);
    using (var nextFrame = mat.ToImage<Bgr, Byte>())
    {
    	if (nextFrame != null)
    	{
    		Image<Gray, byte> grayframe = nextFrame.Convert<Gray, byte>();
    		Rectangle[] faces = mHaarCascade.DetectMultiScale(grayframe, 1.1, 10, Size.Empty);
    		if (faces.Count() > 0)
    		{
    			// some faces are detected
                // you can check the X and Y of faces here
    		}
    	}
    }
    
    private Mat GetMatFromSDImage(Bitmap image)
    {
    	int stride = 0;
    
    	System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, image.Width, image.Height);
    	System.Drawing.Imaging.BitmapData bmpData = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, image.PixelFormat);
    
    	System.Drawing.Imaging.PixelFormat pf = image.PixelFormat;
    	if (pf == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
    	{
    		stride = image.Width * 4;
    	}
    	else
    	{
    		stride = image.Width * 3;
    	}
    
    	Image<Bgra, byte> cvImage = new Image<Bgra, byte>(image.Width, image.Height, stride, (IntPtr)bmpData.Scan0);
    
    	image.UnlockBits(bmpData);
    
    	return cvImage.Mat;
    }
