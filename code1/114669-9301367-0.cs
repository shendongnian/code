	using System.Drawing;
	using System.Drawing.Drawing2D;
	using System.Drawing.Imaging;
	using System.IO;
	namespace ConsoleApplication1
	{
		public class Program
		{
			public static void Main(string[] args)
			{
				var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
				ResizeImage(path, "large.jpg", path, "new.jpg", 100, 100, true, true);
			}
			/// <summary>Resizes an image to a new width and height.</summary>
			/// <param name="originalPath">The folder which holds the original image.</param>
			/// <param name="originalFileName">The file name of the original image.</param>
			/// <param name="newPath">The folder which will hold the resized image.</param>
			/// <param name="newFileName">The file name of the resized image.</param>
			/// <param name="maximumWidth">When resizing the image, this is the maximum width to resize the image to.</param>
			/// <param name="maximumHeight">When resizing the image, this is the maximum height to resize the image to.</param>
			/// <param name="enforceRatio">Indicates whether to keep the width/height ratio aspect or not. If set to false, images with an unequal width and height will be distorted and padding is disregarded. If set to true, the width/height ratio aspect is maintained and distortion does not occur.</param>
			/// <param name="addPadding">Indicates whether fill the smaller dimension of the image with a white background. If set to true, the white padding fills the smaller dimension until it reach the specified max width or height. This is used for maintaining a 1:1 ratio if the max width and height are the same.</param>
			private static void ResizeImage(string originalPath, string originalFileName, string newPath, string newFileName, int maximumWidth, int maximumHeight, bool enforceRatio, bool addPadding)
			{
				var image = Image.FromFile(originalPath + "\\" + originalFileName);
				var imageEncoders = ImageCodecInfo.GetImageEncoders();
				EncoderParameters encoderParameters = new EncoderParameters(1);
				encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, 100L);
				var canvasWidth = maximumWidth;
				var canvasHeight = maximumHeight;
				var newImageWidth = maximumWidth;
				var newImageHeight = maximumHeight;
				var xPosition = 0;
				var yPosition = 0;
				if (enforceRatio)
				{
					var ratioX = maximumWidth / (double)image.Width;
					var ratioY = maximumHeight / (double)image.Height;
					var ratio = ratioX < ratioY ? ratioX : ratioY;
					newImageHeight = (int)(image.Height * ratio);
					newImageWidth = (int)(image.Width * ratio);
					if (addPadding)
					{
						xPosition = (int)((maximumWidth - (image.Width * ratio)) / 2);
						yPosition = (int)((maximumHeight - (image.Height * ratio)) / 2);
					}
					else
					{
						canvasWidth = newImageWidth;
						canvasHeight = newImageHeight;					
					}
				}
				var thumbnail = new Bitmap(canvasWidth, canvasHeight);
				var graphic = Graphics.FromImage(thumbnail);
				if (enforceRatio && addPadding)
				{
					graphic.Clear(Color.White);
				}
				graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphic.SmoothingMode = SmoothingMode.HighQuality;
				graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
				graphic.CompositingQuality = CompositingQuality.HighQuality;
				graphic.DrawImage(image, xPosition, yPosition, newImageWidth, newImageHeight);
				thumbnail.Save(newPath + "\\" + newFileName, imageEncoders[1], encoderParameters);
			}
		}
	}
