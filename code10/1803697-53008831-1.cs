var image = DrawTextImage(TextForImage, font, Color.Black, Color.Transparent);
    public class TextToImage
	{
        // main method you need to call.
		public byte[] GetImageFromText(string TextForImage)
		{
			FontFamily fontFamily = new FontFamily("Arial");
			Font font = new Font(fontFamily, 40.0f);
			var image = DrawTextImage(TextForImage, font, Color.Black, Color.Transparent);
			var imgData = ImageToByteArray(image);
			return imgData;
		}
        // convert image to byte array
		private byte[] ImageToByteArray(System.Drawing.Image imageIn)
		{
			MemoryStream ms = new MemoryStream();
			imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
			return ms.ToArray();
		}
        
		private Image DrawTextImage(String text, Font font, Color textColor, Color backColor)
		{
			return DrawTextImage(text, font, textColor, backColor, new Size(500, 500));
		}
        // create image
		private Image DrawTextImage(String text, Font font, Color textColor, Color backColor, Size minSize)
		{
			//first, create a dummy bitmap just to get a graphics object
			SizeF textSize;
			using (Image img = new Bitmap(1, 1))
			{
				using (Graphics drawing = Graphics.FromImage(img))
				{
					//measure the string to see how big the image needs to be
					textSize = drawing.MeasureString(text, font);
					if (!minSize.IsEmpty)
					{
						textSize.Width = textSize.Width > minSize.Width ? textSize.Width : minSize.Width;
						textSize.Height = textSize.Height > minSize.Height ? textSize.Height : minSize.Height;
					}
				}
			}
			//create a new image of the right size
			//Image retImg = new Bitmap((int)textSize.Width, (int)textSize.Height);
			Image retImg = new Bitmap(500, 500);
			using (var drawing = Graphics.FromImage(retImg))
			{
				//paint the background
				drawing.Clear(backColor);
				//create a brush for the text
				using (Brush textBrush = new SolidBrush(textColor))
				{
					drawing.TextRenderingHint = TextRenderingHint.AntiAlias;
					RectangleF rectF1 = new RectangleF(10, 10, 490, 490);
					drawing.DrawString(text, font, textBrush, rectF1);
					drawing.Save();
				}
			}
			return retImg;
		}
	}
