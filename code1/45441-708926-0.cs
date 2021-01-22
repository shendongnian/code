    private void TestBackGround()
        {
            // Create a red and black bitmap to demonstrate transparency.            
            Bitmap tempBMP = new Bitmap(this.Width, this.Height);
            Graphics g = Graphics.FromImage(tempBMP);
            g.FillEllipse(new SolidBrush(Color.Red), 0, 0, tempBMP.Width, tempBMP.Width);
            g.DrawLine(new Pen(Color.Black), 0, 0, tempBMP.Width, tempBMP.Width);
            g.DrawLine(new Pen(Color.Black), tempBMP.Width, 0, 0, tempBMP.Width);
            g.Dispose();
    
    
            // Set the transparancy key attributes,at current it is set to the 
            // color of the pixel in top left corner(0,0)
            ImageAttributes attr = new ImageAttributes();
            attr.SetColorKey(tempBMP.GetPixel(0, 0), tempBMP.GetPixel(0, 0));
    
            // Draw the image to your output using the transparancy key attributes
            Bitmap outputImage = new Bitmap(this.Width,this.Height);
            g = Graphics.FromImage(outputImage);
            Rectangle destRect = new Rectangle(0, 0, tempBMP.Width, tempBMP.Height);
            g.DrawImage(tempBMP, destRect, 0, 0, tempBMP.Width, tempBMP.Height,GraphicsUnit.Pixel, attr);
    
    
            g.Dispose();
            tempBMP.Dispose();
            this.BackgroundImage = outputImage;
            
        }
