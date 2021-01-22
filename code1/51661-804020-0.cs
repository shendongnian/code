    var newImg = new Bitmap(newWidth, newHeight);
    Graphics g = Graphics.FromImage(newImg);
    g.DrawImage(origImg, new Rectangle(0,0,newWidth,newHeight));
    newImg.Save(this.GetBitmapPath(filename), System.Drawing.Imaging.ImageFormat.Bmp);
    g.Dispose();
