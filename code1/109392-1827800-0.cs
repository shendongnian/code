    private void SaveImageToJPEG(Image ImageToSave, string Location)
            {
                RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)ImageToSave.Source.Width,
                                                                               (int)ImageToSave.Source.Height,
                                                                               100, 100, PixelFormats.Default);
                renderTargetBitmap.Render(ImageToSave);
                JpegBitmapEncoder jpegBitmapEncoder = new JpegBitmapEncoder();
                jpegBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
                using (FileStream fileStream = new FileStream(Location, FileMode.Create))
                {
                    jpegBitmapEncoder.Save(fileStream);
                    fileStream.Flush();
                    fileStream.Close();
                }
            }
