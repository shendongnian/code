    void onCurrentTimeInvalidated (object sender, EventArgs e)
            {
                prefix = "";
                if (counter < 10)
                {
                    prefix = "000";
                }
                else if (counter < 100)
                {
                    prefix = "00";
                }
                else if (counter < 1000)
                {
                    prefix = "0";
                }
    
                Size size = new Size(MainCanvas.ActualWidth, MainCanvas.ActualHeight);
                MainCanvas.Measure(size);
                MainCanvas.Arrange(new Rect(size));
    
    
                RenderTargetBitmap bmp = new RenderTargetBitmap(imgWidth, imgHeight, 96d, 96d, PixelFormats.Default);
                bmp.Render(MainCanvas);
                
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.QualityLevel = 90;
                encoder.Frames.Add(BitmapFrame.Create(bmp));
                string file = basePath + prefix + counter.ToString() + "_testpic.jpg";
                using (Stream stm = File.Create(file))
                {
                    encoder.Save(stm);
                }
                counter++;
            }
