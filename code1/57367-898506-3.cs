        private static void XorFrames(Bitmap leftFrame, Bitmap rightFrame)
        {
            if (leftFrame.Size != rightFrame.Size)
            {
                throw new ArgumentException();
            }
            Rectangle lockArea = new Rectangle(Point.Empty, leftFrame.Size);
            PixelFormat format = PixelFormat.Format32bppArgb;
            BitmapData leftData = leftFrame.LockBits(lockArea, ImageLockMode.ReadWrite, format);
            BitmapData rightData = rightFrame.LockBits(lockArea, ImageLockMode.ReadOnly, format);
            int len = leftData.Height * Math.Abs(rightData.Stride) / 4;
            unsafe
            {
                int* pLeft = (int*)leftData.Scan0;
                int* pRight = (int*)rightData.Scan0;
                for (int i = 0; i < len; i++)
                {
                    *pLeft++ ^= *pRight++;
                }
            }
            leftFrame.UnlockBits(leftData);
            rightFrame.UnlockBits(rightData);
        }
