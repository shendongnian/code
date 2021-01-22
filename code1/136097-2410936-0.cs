		static void Main(string[] args)
		{
			ushort nbCopies = 2;
			Bitmap srcBitmap = (Bitmap)Image.FromFile(@"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg");
			Bitmap dstBitmap = new Bitmap(srcBitmap.Width * nbCopies, srcBitmap.Height, srcBitmap.PixelFormat);
			
			//Slow method
			for (int curCopy = 0; curCopy < nbCopies; curCopy++)
			{
				for (int x = 0; x < srcBitmap.Width; x++)
				{
					for (int y = 0; y < srcBitmap.Height; y++)
					{
						Color c = srcBitmap.GetPixel(x, y);
						dstBitmap.SetPixel(x + (curCopy * srcBitmap.Width), y, c);
					}
				}
			}
			//OR
			//Fast method using unsafe code
			BitmapData srcBd = srcBitmap.LockBits(new Rectangle(Point.Empty, srcBitmap.Size), ImageLockMode.ReadOnly, srcBitmap.PixelFormat);
			BitmapData dstBd = dstBitmap.LockBits(new Rectangle(Point.Empty, dstBitmap.Size), ImageLockMode.WriteOnly, dstBitmap.PixelFormat);
			unsafe
			{
				for (int curCopy = 0; curCopy < nbCopies; curCopy++)
				{
					for (int y = 0; y < srcBitmap.Height; y++)
					{
                        byte* srcRow = (byte*)srcBd.Scan0 + (y * srcBd.Stride);
						byte* dstRow = (byte*)dstBd.Scan0 + (y * dstBd.Stride) + (curCopy * srcBd.Stride);
						
						for (int x = 0; x < srcBitmap.Width; x++)
						{
							//Copy each composant value (typically RGB)
							for (int comp = 0; comp < (srcBd.Stride / srcBd.Width); comp++)
							{
								dstRow[x * 3 + comp] = srcRow[x * 3 + comp];
							}
						}
					}
				}
			}
			dstBitmap.UnlockBits(dstBd);
			srcBitmap.UnlockBits(srcBd);
			dstBitmap.Save(@"C:\Users\Public\Pictures\Sample Pictures\Koala_multiple.jpg");
			dstBitmap.Dispose();
			srcBitmap.Dispose();
		}
