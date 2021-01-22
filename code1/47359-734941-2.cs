    Rectangle cropRect = new Rectangle(...);
    Bitmap src = Image.FromFile(fileName) as Bitmap;
    Bitmap target = new Bitmap(cropRect.Width, cropRect.Height);
    
    using(Graphics g = Graphics.FromImage(target))
    {
       g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height), 
                        cropRect,                        
                        GraphicsUnit.Pixel);
    }
