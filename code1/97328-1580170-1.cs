    /// <summary>
    /// Grayscales a given image.
    /// </summary>
    /// <param name="image">
    /// The image that is transformed to a grayscale image.
    /// </param>
    public static void GrayScaleImage(Bitmap image)
    {
        if (image == null)
            throw new ArgumentNullException("image");
        // lock the bitmap.
        var data = image.LockBits(
                      new Rectangle(0, 0, image.Width, image.Height), 
                      ImageLockMode.ReadWrite, image.PixelFormat);
        try
        {
            unsafe
            {
                // get a pointer to the data.
                byte* ptr = (byte*)data.Scan0;
                // loop over all the data.
                for (int i = 0; i < data.Height; i++)
                {
                    for (int j = 0; j < data.Width; j++)
                    {
                        // calculate the gray value.
                        byte y = (byte)(
                            (0.299 * ptr[2]) + 
                            (0.587 * ptr[1]) + 
                            (0.114 * ptr[0]));
                        // set the gray value.
                        ptr[0] = ptr[1] = ptr[2] = y;
                        // increment the pointer.
                        ptr += 3;
                    }
                    // move on to the next line.
                    ptr += data.Stride - data.Width * 3;
                }
            }
        }
        finally
        {
            // unlock the bits when done or when 
            // an exception has been thrown.
            image.UnlockBits(data);
        }
    }
