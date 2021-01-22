    [System.Runtime.InteropServices.DllImport("gdi32.dll")]
    public static extern bool DeleteObject(IntPtr hObject);
    
    private void DoGetHbitmap() 
    {
        Bitmap bm = new Bitmap("Image.jpg");
        IntPtr hBitmap = bm.GetHbitmap();
                 
        DeleteObject(hBitmap);
    }
