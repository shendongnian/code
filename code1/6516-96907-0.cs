    Bitmap image1 = ...
    Bitmap image2 = ...
    
    Bitmap combined = new Bitmap(image1.Width, image1.Height);
    using (Graphics g = Graphics.FromImage(combined)) {
      g.DrawImage(image1, new Point(0, 0));
      g.DrawImage(image2, new Point(0, 0);
    }
    imageList.Add(combined);
