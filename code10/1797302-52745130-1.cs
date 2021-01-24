    //Note this has several overloads, including a path to an image
    //Use the proper one for yourself
    Bitmap b = new Bitmap(_image);
    
    //Lock(and Load baby) 
    BitmapData bData = b.LockBits(new Rectangle(0, 0, _image.Width, _image.Height), ImageLockMode.ReadWrite, b.PixelFormat);
    //Bits per pixel, obviously
    byte bitsPerPixel = Image.GetPixelFormatSize(bitmap.PixelFormat);
    //Gets the address of the first pixel data in the bitmap.
    //This can also be thought of as the first scan line in the bitmap.
    byte* scan0 = (byte*)bData.Scan0.ToPointer();
    for (int i = 0; i < bData.Height; ++i)
    {
        for (int j = 0; j < bData.Width; ++j)
        {
            byte* data = scan0 + i * bData.Stride + j * bitsPerPixel / 8;
            //data is a pointer to the first byte of the 3-byte color data
            //Do your magic here, compare your RGB values here 
             byte R = *b;     //Dereferencing pointer here
             byte G = *(b+1); 
             byte B = *(b+2); 
        }
    }
    //Unlocking here is important or memoryleak
    b.UnlockBits(bData);
