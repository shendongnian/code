          var image = sender as Image;
            var bitmap = image.Source as WriteableBitmap;
            var prx = new WpfImage.MyToolkit.WriteableBitmapProxy()
            {
                BackBuffer = bitmap.BackBuffer,
                BackBufferStride = bitmap.BackBufferStride,
                PixelHeight = bitmap.PixelHeight,
                PixelWidth = bitmap.PixelWidth
            };
            bitmap.Lock();
            Thread loader = new Thread(new ThreadStart(() => 
            {
                Global_Histogramm(prx);
                Dispatcher.BeginInvoke(DispatcherPriority.Background,
                      (SendOrPostCallback)delegate { bitmap.AddDirtyRect(new Int32Rect(0, 0, prx.PixelWidth - 1, prx.PixelHeight - 1)); bitmap.Unlock(); }, null);
            }
            
            ));
            loader.Priority = ThreadPriority.Lowest;
            loader.Start();
