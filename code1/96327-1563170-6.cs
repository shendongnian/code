    /*Note unsafe keyword*/
    public unsafe Image ThresholdUA(float thresh)
    {
        Bitmap b = new Bitmap(_image);//note this has several overloads, including a path to an image
        BitmapData bData = b.LockBits(new Rectangle(0, 0, _image.Width, _image.Height), ImageLockMode.ReadWrite, b.PixelFormat);
        byte bitsPerPixel = GetBitsPerPixel(bData.PixelFormat);
        /*This time we convert the IntPtr to a ptr*/
        byte* scan0 = (byte*)bData.Scan0.ToPointer();
        for (int i = 0; i < bData.Height; ++i)
        {
            for (int j = 0; j < bData.Width; ++j)
            {
                byte* data = scan0 + i * bData.Stride + j * bitsPerPixel / 8;
                //data is a pointer to the first byte of the 3-byte color data
                //data[0] = blueComponent;
                //data[1] = greenComponent;
                //data[2] = redComponent;
            }
        }
        b.UnlockBits(bData);
        return b;
    }
