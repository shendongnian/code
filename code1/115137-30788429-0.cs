You can compose images using System.Drawing
    //1. create a bitmap (create a empty one or from file)
    Bitmap bmpPic = new Bitmap(imgWidth,imgHeight);
    
    //2. pass that bitmap into Graphics
    using (Graphics g = Graphics.FromImage(bmpPic))
    {
        //manipulate the image
    }
    
    //3. save the bitmap back to a filestream
    bmpPic.Save(imgFileStream,ImageFormat.Png);
