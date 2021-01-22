    public void CaptureApplication(string procName)
    {
    	var proc = Process.GetProcessesByName(procName)[0];
    	var rect = new User32.Rect();
    	User32.GetWindowRect(proc.MainWindowHandle, ref rect);
    
    	int width = rect.right - rect.left;
    	int height = rect.bottom - rect.top;
    
    	var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
    	Graphics graphics = Graphics.FromImage(bmp);
    	graphics.CopyFromScreen(rect.left, rect.top, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);
    	
    	bmp.Save("c:\\tmp\\test.png", ImageFormat.Png);
    }
    
    private class User32
    {
    	[StructLayout(LayoutKind.Sequential)]
    	public struct Rect
    	{
    		public int left;
    		public int top;
    		public int right;
    		public int bottom;
    	}
    
    	[DllImport("user32.dll")]
    	public static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);
    }
