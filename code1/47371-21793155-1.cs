    Image myImage = Image.FromFile(@"C:\imagenes\myImage.gif");
    Bitmap croppedBitmap = new Bitmap(myImage);
    croppedBitmap = croppedBitmap.Clone(
                new Rectangle(
                    (int)LeftMargin.Value, (int)TopMargin.Value,
                    myImage.Width - (int)LeftMargin.Value,
                    myImage.Height - (int)TopMargin.Value),
                System.Drawing.Imaging.PixelFormat.DontCare);
    pictureBox1.Image = croppedBitmap;
