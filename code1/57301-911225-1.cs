    [DllImport("user32.dll")]
    public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
    [DllImport("user32.dll")]
    public static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);
    public static Bitmap PrintWindow(IntPtr hwnd)    
    {       
        RECT rc;        
        GetWindowRect(hwnd, out rc);
       
        Bitmap bmp = new Bitmap(rc.Width, rc.Height, PixelFormat.Format32bppArgb);        
        Graphics gfxBmp = Graphics.FromImage(bmp);        
        IntPtr hdcBitmap = gfxBmp.GetHdc();        
        PrintWindow(hwnd, hdcBitmap, 0);  
      
        gfxBmp.ReleaseHdc(hdcBitmap);            	
        gfxBmp.Dispose(); 
       
        return bmp;   
    }
