	using System.Linq;
	using System.Windows;
	using System.Windows.Media;
	using System.Windows.Media.Imaging;
	using PDFiumSharp;
	static class PdfRenderer
	{
		public static ImageSource RenderPage(string filename, int pageIndex, string password = null, bool withTransparency = true)
		{
			using (var doc = new PdfDocument(filename, password))
			{
				var page = doc.Pages[pageIndex];
				using (var bitmap = new PDFiumBitmap((int)page.Width, (int)page.Height, withTransparency))
				{
					page.Render(bitmap);
					return new BmpBitmapDecoder(bitmap.AsBmpStream(), BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
				}
			}
		}
	}
