    Bitmap myImage = new Bitmap(50, 50); //assuming you want you image to be 50,50
    Bitmap originalImage = new Bitmap("myPngSource.png"); //original image to copy
    using (Graphics g = Graphics.FromImage(myImage))
    {
         g.DrawImage(originalImage, new Rectangle(0, 0, originalImage.Width, originalImage.Height));
    }
    MemoryStream ms = new MemoryStream();
    myImage.Save(ms, ImageFormat.Png);
    BitmapImage bi = new BitmapImage();
    bi.BeginInit();
    bi.StreamSource = ms;
    bi.EndInit();
    MyImageControl.Source = bi;
