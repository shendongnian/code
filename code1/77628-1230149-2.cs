    temp = new Bitmap(newWidth, newHeight, PIXEL_FORMAT);
    temp.SetResolution(newHorizontalRes, newVerticalRes);
    gr = Graphics.FromImage(temp);
    //
    // This copies the active frame from 'img' to the new 'temp' bitmap.
    // Also resizes it and makes it super shiny.  Sparkle on, mr image dude.
    // 
    Rectangle rect = new Rectangle(0, 0, newWidth, newHeight);
    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
    gr.SmoothingMode = SmoothingMode.HighSpeed;
    gr.PageUnit = GraphicsUnit.Pixel;
    gr.DrawImage(img, rect);
    //
    // Image copied onto the new bitmap.  Save the bitmap to a fresh memory stream.
    //
    retval = new UploadedImage();
    retval.BaseStream = (Stream)(new MemoryStream());
    temp.Save(retval.BaseStream, ImageFormat.Jpeg);
    retval.Img = temp;
