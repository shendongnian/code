    	System.Drawing.Point start = System.Drawing.Point.Empty;
    	System.Drawing.Point end = System.Drawing.Point.Empty;
    	
    	int bitmapWidth = bmp.Width;
    	int bitmapHeight = bmp.Height;
    	
    	#region find start and end point
    	System.Drawing.Imaging.BitmapData data = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bitmapWidth, bitmapHeight), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
    	try
    	{
    	    unsafe
    	    {
    	        byte* pData0 = (byte*)data.Scan0;
    	        for (int y = 0; y < bitmapHeight; y++)
    	        {
    	            for (int x = 0; x < bitmapWidth; x++)
    	            {
    	                byte* pData = pData0 + (y * data.Stride) + (x * 4);
    	
    	                byte xyBlue = pData[0];
    	                byte xyGreen = pData[1];
    	                byte xyRed = pData[2];
    	                byte xyAlpha = pData[3];
    	
    	
    	                if (color.A != xyAlpha
    	                        || color.B != xyBlue
    	                        || color.R != xyRed
    	                        || color.G != xyGreen)
    	                {
    	                    //ignore transparent pixels
    	                    if (xyAlpha == 0)
    	                        continue;
    	                    if (start.IsEmpty)
    	                    {
    	                        start = new System.Drawing.Point(x, y);
    	                    }
    	                    else if (start.Y > y)
    	                    {
    	                        start.Y = y;
    	                    }
    	                    if (end.IsEmpty)
    	                    {
    	                        end = new System.Drawing.Point(x, y);
    	                    }
    	                    else if (end.X < x)
    	                    {
    	                        end.X = x;
    	                    }
    	                    else if (end.Y < y)
    	                    {
    	                        end.Y = y;
    	                    }
    	                }
    	            }
    	        }
    	    }
    	}
    	finally
    	{
    	    bmp.UnlockBits(data);
    	}
    	#endregion
