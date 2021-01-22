    Image playbutton;
    try
    {
    	Playbutton = Image.FromFile(/*somekindofpath*/);
    }
    catch (Exception ex)
    {
    	return
    }
    
    Image frame;
    try
    {
    	frame = Image.FromFile(/*somekindofpath*/);
    }
    catch (Exception ex)
    {
    	return
    }
    
    using (frame)
    {
    	using (var bitmap = new Bitmap(width, height))
    	{
    		using (var canvas = Graphics.FromImage(bitmap))
    		{
    			canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
    			canvas.DrawImage(frame, new Rectangle(0, 0, width, height), new Rectangle(0, 0, frame.Width, frame.Height), GraphicsUnit.Pixel);
    			canvas.DrawImage(playbutton, (bitmap.Width / 2) - (playbutton_width / 2 + 5), (bitmap.Height / 2) - (playbutton_height / 2 + 5));
    			canvas.Save();
    		}
    		try
    		{
    			bitmap.Save(/*somekindofpath*/, ImageFormat.Jpeg);
    		}
    		catch (Exception ex) { }
    	}
    }
