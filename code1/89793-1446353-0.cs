    private double ToDegrees(decimal slope) { return (180.0 / Math.PI) * Math.Atan(Convert.ToDouble(slope)); }
    private double GetSkew(Bitmap image)
    {
        BrightnessWrapper wrapper = new BrightnessWrapper(image);
        LinkedList<decimal> slopes = new LinkedList<decimal>();
        Graphics g = pictureBox1.CreateGraphics();
        for (int y = 0; y < wrapper.Height; y++)
        {
            int endY = y;
            long sumOfX = 0;
            long sumOfY = y;
            long sumOfXY = 0;
            long sumOfXX = 0;
            int itemsInSet = 1;
            for (int x = 1; x < wrapper.Width; x++)
            {
                int aboveY = endY - 1;
                int belowY = endY + 1;
                if (aboveY < 0 || belowY >= wrapper.Height)
                {
                    break;
                }
                int center = wrapper.GetBrightness(x, endY);
                int above = wrapper.GetBrightness(x, aboveY);
                int below = wrapper.GetBrightness(x, belowY);
                if (center >= above && center >= below) { /* no change to endY */ }
                else if (above >= center && above >= below) { endY = aboveY; }
                else if (below >= center && below >= above) { endY = belowY; }
                itemsInSet++;
                sumOfX += x;
                sumOfY += endY;
                sumOfXX += (x * x);
                sumOfXY += (x * endY);
            }
            // least squares slope = (NΣ(XY) - (ΣX)(ΣY)) / (NΣ(X^2) - (ΣX)^2), where N = elements in set
            if (itemsInSet > image.Width / 2) // path covers at least half of the image
            {
                decimal sumOfX_d = Convert.ToDecimal(sumOfX);
                decimal sumOfY_d = Convert.ToDecimal(sumOfY);
                decimal sumOfXY_d = Convert.ToDecimal(sumOfXY);
                decimal sumOfXX_d = Convert.ToDecimal(sumOfXX);
                decimal itemsInSet_d = Convert.ToDecimal(itemsInSet);
                decimal slope =
                    ((itemsInSet_d * sumOfXY) - (sumOfX_d * sumOfY_d))
                    /
                    ((itemsInSet_d * sumOfXX_d) - (sumOfX_d * sumOfX_d));
                slopes.AddLast(slope);
            }
        }
    }
    class BrightnessWrapper
    {
        byte[] rgbValues;
        int stride;
        public int Height { get; private set; }
        public int Width { get; private set; }
        public BrightnessWrapper(Bitmap bmp)
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData =
                bmp.LockBits(rect,
                    System.Drawing.Imaging.ImageLockMode.ReadOnly,
                    bmp.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            int bytes = bmpData.Stride * bmp.Height;
            this.rgbValues = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(ptr,
                           rgbValues, 0, bytes);
            this.Height = bmp.Height;
            this.Width = bmp.Width;
            this.stride = bmpData.Stride;
        }
        public int GetBrightness(int x, int y)
        {
            int position = (y * this.stride) + (x * 3);
            int b = rgbValues[position];
            int g = rgbValues[position + 1];
            int r = rgbValues[position + 2];
            return (r + r + b + g + g + g) / 6;
        }
    }
