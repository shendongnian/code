		public static Bitmap ResizeBitmapOnWhiteCanvas(Bitmap bmpOriginal, Size szTarget, bool Stretch)
		{
			Bitmap result = new Bitmap(szTarget.Width, szTarget.Height);
			using (Graphics g = Graphics.FromImage((Image)result))
			{
				g.InterpolationMode = InterpolationMode.NearestNeighbor;
				g.FillRectangle(Brushes.White, new Rectangle(0, 0, szTarget.Width, szTarget.Height));
				if (Stretch)
				{
					g.DrawImage(bmpOriginal, 0, 0, szTarget.Width, szTarget.Height); // fills the square (stretch)
				}
				else
				{
					float OriginalAR = bmpOriginal.Width / bmpOriginal.Height;
					float TargetAR = szTarget.Width / szTarget.Height;
					if (OriginalAR >= TargetAR)
					{
						// Original is wider than target
						float X = 0F;
						float Y = ((float)szTarget.Height / 2F) - ((float)szTarget.Width / (float)bmpOriginal.Width * (float)bmpOriginal.Height) / 2F;
						float Width = szTarget.Width;
						float Height = (float)szTarget.Width / (float)bmpOriginal.Width * (float)bmpOriginal.Height;
						g.DrawImage(bmpOriginal, X, Y, Width, Height);
					}
					else
					{
						// Original is narrower than target
						float X = ((float)szTarget.Width / 2F) - ((float)szTarget.Height / (float)bmpOriginal.Height * (float)bmpOriginal.Width) / 2F;
						float Y = 0F;
						float Width = (float)szTarget.Height / (float)bmpOriginal.Height * (float)bmpOriginal.Width;
						float Height = szTarget.Height;
						g.DrawImage(bmpOriginal, X, Y, Width, Height);
					}
				}
			}
			return result;
		}
