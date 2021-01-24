       //load input image (bitmap)
        Bitmap image1 = new Bitmap(@"C:\image\image1.bmp");
        //create output image (bitmap) and set the new pixel format
        Bitmap image2 = new Bitmap(image1.Width, image1.Height,
            System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        //draw the input image on the output image within a specified rectangle (area)
        using (Graphics gr = Graphics.FromImage(image2)) {
            gr.DrawImage(image1, new Rectangle(0, 0, image2.Width, image2.Height));
        }
        //save output image
        image2.Save(@"C:\image\image2.bmp");
