                for (int j = 0; j < samp.PixelHeight / tileHeight; j++)
                {
                    for (int i = 0; i < samp.PixelWidth / tileWidth; i++)
                    {
                        CroppedBitmap c = new CroppedBitmap((BitmapSource)this.Resources["masterImage"],
                        new Int32Rect(i * tileWidth, j * tileHeight, tileWidth, tileHeight));
                        System.Windows.Controls.Image a = new System.Windows.Controls.Image();
                        a.Width = 64;
                        a.Height = 64;
                        a.Source = c;
                        ImageStack.Children.Add(a);
                    }
                }
