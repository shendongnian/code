    BitmapSource BitmapSource;
    private void OpenFile(Object sender, RoutedEventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "PNG files (*.png)|*.png|TIFF files (*.tif)|*.tif";            
            
            if (OpenFileDialog.ShowDialog() == true)
            {
                try
                {
                    if (OpenFileDialog.OpenFile() != null)
                    {
                        String InitialPath = OpenFileDialog.FileName;                       
                        FileStream InitialFileStream = new FileStream(InitialPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                        switch (OpenFileDialog.FilterIndex)
                        {
                            case 1:
                                PngBitmapDecoder PngBitmapDecoder = new PngBitmapDecoder(InitialFileStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                                BitmapSource = PngBitmapDecoder.Frames[0];
                                InitialFileStream.Close();
                                break;
                            case 2:
                                TiffBitmapDecoder TiffBitmapDecoder = new TiffBitmapDecoder(InitialFileStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                                BitmapSource = TiffBitmapDecoder.Frames[0];
                                InitialFileStream.Close();
                                break;
                        }  
                    }
                }
                catch (Exception Exception)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: ", Exception.Message, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    
