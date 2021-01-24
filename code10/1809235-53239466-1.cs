            public static Bitmap Scale(int count, Bitmap source)
        {
            if (count <= 0) { return source; }
            var bitmap = new Bitmap(source.Size.Width * count, source.Size.Height * count);
            var sourcedata = source.LockBits(new Rectangle(new System.Drawing.Point(0, 0), source.Size), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            var bitmapdata = bitmap.LockBits(new Rectangle(new System.Drawing.Point(0, 0), bitmap.Size), ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            unsafe
            {
                var srcByte = (byte*)sourcedata.Scan0.ToPointer();
                var dstByte = (byte*)bitmapdata.Scan0.ToPointer();
                for (var y = 0; y < bitmapdata.Height; y++) {
                    for (var x = 0; x < bitmapdata.Width; x++) {
                        long index = (x / count) * 4 + (y / count) * sourcedata.Stride;
                        dstByte[0] = srcByte[index];
                        dstByte[1] = srcByte[index + 1];
                        dstByte[2] = srcByte[index + 2];
                        dstByte[3] = srcByte[index + 3];
                        dstByte += 4;
                    }
                }
            }
            source.UnlockBits(sourcedata);
            bitmap.UnlockBits(bitmapdata);
            return bitmap;
        }
