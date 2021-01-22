    public class WebBrowserEx : WebBrowser
    {
        private const uint DVASPECT_CONTENT = 1;
    
        [DllImport("ole32.dll", PreserveSig = false)]
        private static extern void OleDraw([MarshalAs(UnmanagedType.IUnknown)] object pUnk,
            uint dwAspect,
            IntPtr hdcDraw,
            [In] ref System.Drawing.Rectangle lprcBounds
        );
       
        protected override void WndProc(ref Message m)
        {
            const int WM_PRINT = 0x0317;
    
            switch (m.Msg)
            {
                case WM_PRINT:
                    Rectangle browserRect = new Rectangle(0, 0, this.Width, this.Height);
    
                    // Don't know why, but drawing with OleDraw directly on HDC from m.WParam.
                    // results in badly scaled (stretched) image of the browser.
                    // So, drawing to an intermediate bitmap first.
                    using (Bitmap browserBitmap = new Bitmap(browserRect.Width, browserRect.Height))
                    {
                        using (var graphics = Graphics.FromImage(browserBitmap))
                        {
                            var hdc = graphics.GetHdc();
                            OleDraw(this.ActiveXInstance, DVASPECT_CONTENT, hdc, ref browserRect);
                            graphics.ReleaseHdc(hdc);
                        }
    
                        using (var graphics = Graphics.FromHdc(m.WParam))
                        {
                            graphics.DrawImage(browserBitmap, Point.Empty);
                        }
                    }
                    // ignore default WndProc
                    return;
    
            }
    
            base.WndProc(ref m);
        }
    }
