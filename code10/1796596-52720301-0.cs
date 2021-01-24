    void Main()
    {
    	Bitmap image = LoadPicture("https://i.stack.imgur.com/ti7Ij.png");
    
    	using (Graphics g = Graphics.FromImage(image))
    	{
    		g.DrawRectangle(new Pen(Color.DarkOliveGreen), new Rectangle(11, 11, 33, 44));
    		g.DrawRectangle(new Pen(Color.DarkOliveGreen), new Rectangle(33, 33, 33, 22));
    		g.DrawRectangle(new Pen(Color.DarkOliveGreen), new Rectangle(33, 11, 22, 44));
    	}
    
    	image.Dump();
    	Bitmap image2 = Lap1(image);
    	image2.Dump();
    }
    
    Bitmap Lap1(Bitmap image)
    {
    	var image2 = new Bitmap(image);
    	for (int x = 1; x < image.Width - 1; x++)
    	{
    		for (int y = 1; y < image.Height - 1; y++)
    		{
    			Color color2, color4, color5, color6, color8;
    			color2 = image.GetPixel(x, y - 1);
    			color4 = image.GetPixel(x - 1, y);
    			color5 = image.GetPixel(x, y);
    			color6 = image.GetPixel(x + 1, y);
    			color8 = image.GetPixel(x, y + 1);
    			int r = color2.R + color4.R + color5.R * (-4) + color6.R + color8.R;
    			int g = color2.G + color4.G + color5.G * (-4) + color6.G + color8.G;
    			int b = color2.B + color4.B + color5.B * (-4) + color6.B + color8.B;
    			int avg = (r + g + b) / 3;
    			if (avg > 255) avg = 255;
    			if (avg < 0) avg = 0;
    			image2.SetPixel(x, y, Color.FromArgb(avg, avg, avg));
    		}
    	}
    	return image2;
    }
    
    private Bitmap LoadPicture(string url)
    {
    	HttpWebRequest wreq;
    	HttpWebResponse wresp;
    	Stream mystream;
    	Bitmap bmp;
    
    	bmp = null;
    	mystream = null;
    	wresp = null;
    	try
    	{
    		wreq = (HttpWebRequest)WebRequest.Create(url);
    		wreq.AllowWriteStreamBuffering = true;
    		wresp = (HttpWebResponse)wreq.GetResponse();
    
    		if ((mystream = wresp.GetResponseStream()) != null)
    			bmp = new Bitmap(mystream);
    	}
    	finally
    	{
    		if (mystream != null)
    			mystream.Close();
    
    		if (wresp != null)
    			wresp.Close();
    	}
    	return (bmp);
    }
