        public static BitmapSource ToBitmapSource(this System.Drawing.Bitmap source)
        {
            var hBitmap = source.GetHbitmap();
            try
            {
                return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
            }
            catch (Win32Exception)
            {
                return null;
            }
            finally
            {
                NativeMethods.DeleteObject(hBitmap);
            }
        }
