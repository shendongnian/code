    [System.Runtime.InteropServices.DllImport("gdi32.dll")]
    public static extern bool DeleteObject(IntPtr hObject);
    
    ...
    
    IntPtr gdiBitmap = bmp.GetHbitmap();
    
    // Release the copied GDI bitmap
    if (pic.Image != null)
    {
        pic.Image.Dispose();
    }
    pic.Image = System.Drawing.Image.FromHbitmap(gdiBitmap);
    
    // Release the current GDI bitmap
    DeleteObject(gdiBitmap);
