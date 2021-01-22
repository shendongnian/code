    	using System.Drawing;
	using System.Drawing.Imaging;
	using System.Windows.Forms;
	
	public class Program
	{
		public static void Main()
		{
			Bitmap bmp = new Bitmap(100, 100, PixelFormat.Format32bppArgb);
			using (Font font = new Font("Arial", 10, GraphicsUnit.Point))
			using (Graphics g = Graphics.FromImage(bmp))
			{
				Rectangle clip = Rectangle.FromLTRB(0, 0, 100, 100);
				g.Clear(Color.Red);
				TextFormatFlags tf = TextFormatFlags.Left;
				TextRenderer.DrawText(g, @"C:\Development\Testing\blag", font, clip, Color.White, Color.Transparent, tf);
			}
			
			Form form = new Form();
			form.BackgroundImage = bmp;
			Application.Run(form);
		}
	}
