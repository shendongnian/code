    [System.Runtime.InteropServices.DllImport("gdi32.dll")]
    public static extern bool DeleteObject(IntPtr hObject);
    
    ...
    
    IntPtr gdiBitmap = bmp.GetHbitmap();
    
    pic.Image = System.Drawing.Image.FromHbitmap(gdiBitmap);
    
    DeleteObject(gdiBitmap);
