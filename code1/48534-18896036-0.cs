		System.Windows.Point position = Mouse.GetPosition(lightningChartUltimate1);
		if (lightningChartUltimate1.ViewXY.IsMouseOverGraphArea((int)position.X, (int)position.Y))
		{
			System.Windows.Point positionScreen = lightningChartUltimate1.PointToScreen(position);
			Color color = WindowHelper.GetPixelColor((int)positionScreen.X, (int)positionScreen.Y);
			Debug.Print(color.ToString());
          ...
          ...
	public class WindowHelper
	{
		// ******************************************************************
		[DllImport("user32.dll")]
		static extern IntPtr GetDC(IntPtr hwnd);
		[DllImport("user32.dll")]
		static extern Int32 ReleaseDC(IntPtr hwnd, IntPtr hdc);
		[DllImport("gdi32.dll")]
		static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);
		static public System.Windows.Media.Color GetPixelColor(int x, int y)
		{
			IntPtr hdc = GetDC(IntPtr.Zero);
			uint pixel = GetPixel(hdc, x, y);
			ReleaseDC(IntPtr.Zero, hdc);
			Color color = Color.FromRgb(
				(byte)(pixel & 0x000000FF),
				(byte)((pixel & 0x0000FF00) >> 8),
				(byte)((pixel & 0x00FF0000) >> 16));
			return color;
		}
