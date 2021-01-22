    private void CaptureScreenAndSave(string strSavePath)
            {
    
                //SetTitle("Capturing Screen...");
    
                Bitmap bmpScreenshot;
    
                Graphics gfxScreenshot;
                bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height,System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                gfxScreenshot = Graphics.FromImage(bmpScreenshot);
                gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
                MemoryStream msIn = new MemoryStream();
                bmpScreenshot.Save(msIn, System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()[0], null);
    
                msIn.Close();
    
                byte[] buf = msIn.ToArray();
    
                MemoryStream msOut = new MemoryStream();
    
                msOut.Write(buf, 0, buf.Length);
    
                msOut.Position = 0;
    
                Bitmap bmpOut = new Bitmap(msOut);
    
                try
                {
                    bmpOut.Save(strSavePath, System.Drawing.Imaging.ImageFormat.Bmp);
                    //SetTitle("Capturing Screen Image Saved...");
                }
    
                catch (Exception exp)
                {
                    
                }
    
                finally
                {
                    msOut.Close();
                }
            }
