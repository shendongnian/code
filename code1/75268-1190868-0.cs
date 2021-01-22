    protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            bool glassEnabled = IsGlassEnabled();
            if (glassEnabled) // draw glass if enabled
            {
                Rectangle rc = picPlaceHolder.ClientRectangle;
                IntPtr destdc = e.Graphics.GetHdc(); // hwnd must be the handle of form, not control
                IntPtr Memdc = CreateCompatibleDC(destdc);
                IntPtr bitmapOld = IntPtr.Zero;
                BITMAPINFO dib = new BITMAPINFO();
                dib.bmiHeader.biHeight = -(rc.Bottom - rc.Top);
                dib.bmiHeader.biWidth = rc.Right - rc.Left;
                dib.bmiHeader.biPlanes = 1;
                dib.bmiHeader.biSize = Marshal.SizeOf(typeof(BITMAPINFOHEADER));
                dib.bmiHeader.biBitCount = 32;
                dib.bmiHeader.biCompression = BI_RGB;
                if (!(SaveDC(Memdc) == 0))
                {
                    IntPtr bitmap = CreateDIBSection(Memdc, ref dib, DIB_RGB_COLORS, 0, IntPtr.Zero, 0);
                    if (!(bitmap == IntPtr.Zero))
                    {
                        bitmapOld = SelectObject(Memdc, bitmap);
                        BitBlt(destdc, rc.Left, rc.Top, rc.Right - rc.Left, rc.Bottom - rc.Top, Memdc, 0, 0, SRCCOPY);
                    }
                    // remember to clean up
                    SelectObject(Memdc, bitmapOld);
                    DeleteObject(bitmap);
                    ReleaseDC(Memdc, -1);
                    DeleteDC(Memdc);
                }
                e.Graphics.ReleaseHdc();
            }
        }
