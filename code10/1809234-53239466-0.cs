        [DllImport("gdi32", EntryPoint = "DeleteObject")]
        public static extern bool DeleteHBitmap(IntPtr hObject);        
        public static BitmapSource ToBitmapSource(this Bitmap target)
        {
            var hbitmap = target.GetHbitmap();
            try {
                return Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
            }
            finally {
                DeleteHBitmap(hbitmap);
            }
        }
