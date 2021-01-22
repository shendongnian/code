    public class GDI
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        internal static extern bool SetPixel(IntPtr hdc, int X, int Y, uint crColor);
    }
    {
        ...
		private void OnPanel_Paint(object sender, PaintEventArgs e)
		{
			int renderWidth = GetRenderWidth();
			int renderHeight = GetRenderHeight();
			IntPtr hdc = e.Graphics.GetHdc();
			for (int y = 0; y < renderHeight; y++)
			{
				for (int x = 0; x < renderWidth; x++)
				{
					Color pixelColor = GetPixelColor(x, y);
                    // NOTE: GDI colors are BGR, not ARGB.
					uint colorRef = (uint)((pixelColor.B << 16) | (pixelColor.G << 8) | (pixelColor.R));
					GDI.SetPixel(hdc, x, y, colorRef);
				}
			}
			e.Graphics.ReleaseHdc(hdc);
		}
        ...
    }
