    int width = 480;
	int height = Int16.MaxValue;
	try
	{
		while(Height <= Int32.MaxValue)
		{
			Image image = new Bitmap(width, height);
			using(MemoryStream ms = new MemoryStream())
			{
				//error will throw from here
				image.Save(ms, ImageFormat.Jpeg);
			}
			height += 100;
			if(height < Int16.MaxValue)
			{
			}
		}
	}
	catch(Exception ex)
	{
		//explodes at 65567 with "A generic error occurred in GDI+."
	}
