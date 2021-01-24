    const int SRCCOPY = 0xCC0020;
    [DllImport("gdi32.dll")]
    static extern int BitBlt(IntPtr hdc, int x, int y, int cx, int cy,
        IntPtr hdcSrc, int x1, int y1, int rop);
    Image PrintClientRectangleToImage()
    {
        var bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
        using (var bmpGraphics = Graphics.FromImage(bmp))
        {
            var bmpDC = bmpGraphics.GetHdc();
            using (Graphics formGraphics = Graphics.FromHwnd(this.Handle))
            {
                var formDC = formGraphics.GetHdc();
                BitBlt(bmpDC, 0, 0, ClientSize.Width, ClientSize.Height, formDC, 0, 0, SRCCOPY);
                formGraphics.ReleaseHdc(formDC);
            }
            bmpGraphics.ReleaseHdc(bmpDC);
        }
        return bmp;
    }
