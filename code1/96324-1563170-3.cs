    /*No unsafe keyword!*/
    public Image ThresholdMA(float thresh)
    {
        Bitmap b = new Bitmap(_image);
        BitmapData bData = b.LockBits(new Rectangle(0, 0, _image.Width, _image.Height), ImageLockMode.ReadWrite, b.PixelFormat);
        /* GetBitsPerPixel just does a switch on the PixelFormat and returns the number */
        byte bitsPerPixel = GetBitsPerPixel(bData.PixelFormat);
        /*the size of the image in bytes */
        int size = bData.Stride * bData.Height;
        /*Allocate buffer for image*/
        byte[] data = new byte[size];
        /*This overload copies data of /size/ into /data/ from location specified (/Scan0/)*/
        System.Runtime.InteropServices.Marshal.Copy(bData.Scan0, data, 0, size);
        for (int i = 0; i < size; i += bitsPerPixel / 8 )
        {
            double magnitude = 1/3d*(data[i] +data[i + 1] +data[i + 2]);
            
            //data[i] is the first of 3 bytes of color
        }
        /* This override copies the data back into the location specified */
        System.Runtime.InteropServices.Marshal.Copy(data, 0, bData.Scan0, data.Length);
        b.UnlockBits(bData);
        return b;
    }
