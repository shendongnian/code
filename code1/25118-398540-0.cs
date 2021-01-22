    public static Bitmap TransformBGRArrayToBitmap(byte[] inputValues, int Width, int Height, int Stride)
    {
        Bitmap output = new Bitmap(Width, Height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
        // Lock the bitmap's bits.  
        Rectangle rect = new Rectangle(0, 0, Width, Height);
        BitmapData outputData = output.LockBits(rect, System.Drawing.Imaging.ImageLockMode.WriteOnly, output.PixelFormat);
        // Get the address of the first line.
        IntPtr outputPtr = outputData.Scan0;
        // Declare an array to hold the bytes of the bitmap.
        byte[] outputValues = new byte[outputData.Stride * output.Height];
        int inputBytesPP = (1 * Stride) / Width;
        int outputBytesBPP = (1 * outputData.Stride) / output.Width;
        // Copy the RGB values into the array.
        for (int inputByte = 0, outputByte = 0; inputByte < inputValues.Length; inputByte += inputBytesPP, outputByte += outputBytesBPP)
        {
            //The logic inside this loop transforms a 32 bit ARGB Bitmap into an 8 bit indexed Bitmap
            //So you will have to replace it
            /*byte pixel = 0x00;
            if (inputValues[inputByte] > 0x7F)
            {
                if (inputValues[inputByte + 1] > 0x7F)
                    pixel |= 0x01;
                if (inputValues[inputByte + 2] > 0x7F)
                    pixel |= 0x02;
                if (inputValues[inputByte + 3] > 0x7F)
                    pixel |= 0x04;
                if ((inputValues[inputByte + 1] & 0x7F) > 0x3F)
                    pixel |= 0x02;
                if ((inputValues[inputByte + 2] & 0x7F) > 0x3F)
                    pixel |= 0x04;
                if ((inputValues[inputByte + 3] & 0x7F) > 0x3F)
                    pixel |= 0x08;
            }
            else
                pixel = 0x10;
            outputValues[outputByte] = pixel;*/
        }
        System.Runtime.InteropServices.Marshal.Copy(outputValues, 0, outputPtr, outputValues.Length);
        output.UnlockBits(outputData);
        return output;
    }
