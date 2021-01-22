    private void Draw()
    {
    	using (Bitmap bmp = (Bitmap)Bitmap.FromFile(@"C:\Jason\forest.jpg"))
    	using (Graphics grDest = Graphics.FromHwnd(pictureBox1.Handle))
    	using (Graphics grSrc = Graphics.FromImage(bmp))
    	{
    		IntPtr hdcDest = IntPtr.Zero;
    		IntPtr hdcSrc = IntPtr.Zero;
    		IntPtr hBitmap = IntPtr.Zero;
    		IntPtr hOldObject = IntPtr.Zero;
    
    		try
    		{
    			hdcDest = grDest.GetHdc();
    			hdcSrc = grSrc.GetHdc();
    			hBitmap = bmp.GetHbitmap();
    
    			hOldObject = SelectObject(hdcSrc, hBitmap);
    			if (hOldObject == IntPtr.Zero)
    				throw new Win32Exception();
    
    			if (!BitBlt(hdcDest, 0, 0, pictureBox1.Width, pictureBox1.Height,
    				hdcSrc, 0, 0, 0x00CC0020U))
    				throw new Win32Exception();
    		}
    		finally
    		{
    			if (hOldObject != IntPtr.Zero) SelectObject(hdcSrc, hOldObject);
    			if (hBitmap != IntPtr.Zero) DeleteObject(hBitmap);
    			if (hdcDest != IntPtr.Zero) grDest.ReleaseHdc(hdcDest);
    			if (hdcSrc != IntPtr.Zero) grSrc.ReleaseHdc(hdcSrc);
    		}
    	}
    }
    
    [DllImport("gdi32.dll", EntryPoint = "SelectObject")]
    public static extern System.IntPtr SelectObject(
    	[In()] System.IntPtr hdc,
    	[In()] System.IntPtr h);
    
    [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool DeleteObject(
    	[In()] System.IntPtr ho);
    
    [DllImport("gdi32.dll", EntryPoint = "BitBlt")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool BitBlt(
    	[In()] System.IntPtr hdc, int x, int y, int cx, int cy,
    	[In()] System.IntPtr hdcSrc, int x1, int y1, uint rop);
