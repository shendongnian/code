    public static void Seed(int px, int py)
    {
    	using (var seed = new Bitmap(256, 256, PixelFormat.Format24bppRgb))
    	{
    		for (var x = 0; x < seed.Width; x++)
    		{
    			for (var y = 0; y < seed.Height; y++)
    			{
    				var val = rng.Next(0, 255);
    				seed.SetPixel(x, y, Color.FromArgb(255, val, val, val));
    			}
    		}
    
    		if (File.Exists("chunk," + (px - 1) + "," + py + ".jpeg"))
    		{
    			using (var source = new Bitmap("chunk," + (px - 1) + "," + py + ".jpeg"))
    			{
    				for (var y = 0; y < 256; y++)
    				{
    					seed.SetPixel(0, y, Color.FromArgb(255, source.GetPixel(255, y).R, source.GetPixel(255, y).G, source.GetPixel(255, y).B));
    				}
    			}
    		}
    
    		if (File.Exists("chunk," + (px + 1) + "," + py + ".jpeg"))
    		{
    			using (var source = new Bitmap("chunk," + (px + 1) + "," + py + ".jpeg"))
    			{
    				for (var y = 0; y < 256; y++)
    				{
    					seed.SetPixel(255, y, Color.FromArgb(255, source.GetPixel(0, y).R, source.GetPixel(0, y).G, source.GetPixel(0, y).B));
    				}
    			}
    		}
    
    		if (File.Exists("chunk," + px + "," + (py - 1) + ".jpeg"))
    		{
    			using (var source = new Bitmap("chunk," + px + "," + (py - 1) + ".jpeg"))
    			{
    				for (var x = 0; x < 256; x++)
    				{
    					seed.SetPixel(x, 0, Color.FromArgb(255, source.GetPixel(x, 255).R, source.GetPixel(x, 255).G, source.GetPixel(x, 255).B));
    				}
    			}
    		}
    
    		if (File.Exists("chunk," + px + "," + (py + 1) + ".jpeg"))
    		{
    			using (var source = new Bitmap("chunk," + px + "," + (py + 1) + ".jpeg"))
    			{
    				for (var x = 0; x < 256; x++)
    				{
    					seed.SetPixel(x, 255, Color.FromArgb(255, source.GetPixel(x, 0).R, source.GetPixel(x, 0).G, source.GetPixel(x, 0).B));
    				}
    			}
    		}
    
    		seed.Save("chunk," + px + "," + py + ".jpeg", ImageFormat.Jpeg);
    	}
    }
