    Image playbutton;
    try
    {
    	playbutton = Image.FromFile(/*somekindofpath*/);
    }
    catch (Exception ex)
    {
    	return;
    }
    
    Image frame;
    try
    {
    	frame = Image.FromFile(/*somekindofpath*/);
    }
    catch (Exception ex)
    {
    	return;
    }
    
    using (frame)
    {
    	using (var bitmap = new Bitmap(width, height))
    	{
    		using (var canvas = Graphics.FromImage(bitmap))
    		{
    			canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
    			canvas.DrawImage(frame,
                                 new Rectangle(0,
                                               0,
                                               width,
                                               height),
                                 new Rectangle(0,
                                               0,
                                               frame.Width,
                                               frame.Height),
                                 GraphicsUnit.Pixel);
    			canvas.DrawImage(playbutton,
                                 (bitmap.Width / 2) - (playbutton.Width / 2),
                                 (bitmap.Height / 2) - (playbutton.Height / 2));
    			canvas.Save();
    		}
    		try
    		{
    			bitmap.Save(/*somekindofpath*/,
                            System.Drawing.Imaging.ImageFormat.Jpeg);
    		}
    		catch (Exception ex) { }
    	}
    }
