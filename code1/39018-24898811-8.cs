    private void ButtonClick(Object sender, RoutedEventArgs e)
        {
            PixelFormat PixelFormat = BitmapSource.Format;
            if (PixelFormat == PixelFormats.Bgra32)
            {
                try
                {
                    BitmapSource = Bgra32ToBgra24(BitmapSource);
                    //BitmapSource = Bgra32ToGray8(BitmapSource);
                }
                catch (Exception Exception)
                {
                    MessageBox.Show("Error: Could not convert BitmapSource. Original error: ", Exception.Message, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
