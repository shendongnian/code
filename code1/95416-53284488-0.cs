     public static InteropBitmap Bitmap2BitmapImage(Bitmap bitmap)
            {
                try
                {
                    var source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
               
                    return (InteropBitmap)source;
    
                }
                catch (Exception e)
                {
                    MessageBox.Show("Convertion exception: " + e.Message + "\n" +e.StackTrace);
                    return null;
                }
            }
