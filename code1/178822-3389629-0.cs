    private void ProcessPhoto()
            {
    
    
                System.Drawing.Image imgThumb = System.Drawing.Image.FromFile("some.jpg");
    
                // 43w, 35h = offset in frame
    
                System.Drawing.Image imgFrame = System.Drawing.Image.FromFile("transparent_something.png");
    
                Bitmap bmImage = new Bitmap(imgThumb);
                bmImage.SetResolution(72, 72);
                Graphics gFrame = Graphics.FromImage(imgFrame);
                gFrame.DrawImage(bmImage, new Point(38, 44)); // offset point of where you want to draw
    
                gFrame.Dispose();
    
                SavePhoto(imgFrame, "dest.png");
    
                imgFrame.Dispose();           
                imgThumb.Dispose();
              
            }
    
            private void SavePhoto(System.Drawing.Image img, string fileName)
            {
                string ext = Path.GetExtension(fileName);
                fileName = fileName.Replace(ext, ".png");            
    
                img.Save(fileName, GetImageEncoder("PNG"), null);
            }
