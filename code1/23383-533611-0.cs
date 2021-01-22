    private void MakeCutList(ImageList sourceList, Color background)
    {
       Brush overlay = new SolidBrush(Color.FromArgb(128, BackColor));
       Rectangle rect = new Rectangle(new Point(0, 0), sourceList.ImageSize);
    
       foreach (Image img in sourceList.Images)
       {
          Bitmap cutBmp = new Bitmap(img.Width, img.Height);
                    
          using (Graphics g = Graphics.FromImage(cutBmp))
          {
             g.DrawImage(img, 0, 0);
             g.FillRectangle(overlay, rect);
          }
    
          sourceList.Images.Add(cutBmp);    
       }
    }
