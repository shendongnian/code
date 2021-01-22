    Bitmap screenShot = null;
             Bitmap croppedImage;
             Graphics screen;
    
             if(saveFileDialog.ShowDialog() == DialogResult.OK)
             {
                this.Hide();
                screenShot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, 
                                        Screen.PrimaryScreen.Bounds.Height,
                                        PixelFormat.Format32bppArgb);
                screen = Graphics.FromImage(screenShot);
                screen.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                        Screen.PrimaryScreen.Bounds.Y,
                                        0,
                                        0,
                                        Screen.PrimaryScreen.Bounds.Size,
                                        CopyPixelOperation.SourceCopy);
                screenShot.Save(saveFileDialog.FileName, ImageFormat.Png);
                this.Show();
             }
    
             //crop image
             if(screenShot != null)
             {
                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                   int x = 100;
                   int y = 100;
                   int xWidth = 100;
                   int yHeight = 100;
                   Rectangle rect = new Rectangle(x, y, xWidth, yHeight);
                   croppedImage = screenShot.Clone(rect, PixelFormat.Format32bppArgb);
                   if (croppedImage != null)
                   {
                      croppedImage.Save(saveFileDialog.FileName, ImageFormat.Png);
                   }     
                }                   
             }
