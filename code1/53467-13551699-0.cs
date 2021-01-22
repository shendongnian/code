        [DllImport("User32.dll")]
        public extern static System.IntPtr GetDC(System.IntPtr hWnd);
        [DllImport("User32.dll")]
        public extern static int ReleaseDC(System.IntPtr hWnd, System.IntPtr hDC); //modified to include hWnd
        //[DllImport("gdi32.dll")]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //internal static extern bool DeleteObject(IntPtr hObject);
        private static Bitmap GetBitmapFromControl(Window element, int width, int height)
        {
            HwndSource hWnd = (HwndSource)HwndSource.FromVisual(element);
            System.IntPtr srcDC = GetDC(hWnd.Handle);
            Bitmap bm = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bm);
            System.IntPtr bmDC = g.GetHdc();
            BitBlt(bmDC, 0, 0, bm.Width, bm.Height, srcDC, 0, 0, 0x00CC0020 /*SRCCOPY*/);
            ReleaseDC(hWnd.Handle, srcDC);
            g.ReleaseHdc(bmDC);
            g.Dispose();
            return bm;
        }
        public static BitmapSource ToWpfBitmap(this Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Bmp);
                stream.Position = 0;
                BitmapImage result = new BitmapImage();
                result.BeginInit();
                // According to MSDN, "The default OnDemand cache option retains access to the stream until the image is needed."
                // Force the bitmap to load right now so we can dispose the stream.
                result.CacheOption = BitmapCacheOption.OnLoad;
                result.StreamSource = stream;
                result.EndInit();
                result.Freeze();
                //DeleteObject(bitmap.GetHbitmap());
                bitmap.Dispose();
                return result;
            }
        }
