    unsafe static bool Compare(Bitmap a, Bitmap b) {
        if(ReferenceEquals(a,b)) return true;
        if(a==null || b==null) return false;
        if(a.Width!=b.Width || a.Height != b.Height) return false;
        BitmapData dataA = null, dataB = null;
        try {
            int height = a.Height, width = a.Width;
            dataA = a.LockBits(new Rectangle(0, 0, width, height), System.Drawing.Imaging.ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            dataB = b.LockBits(new Rectangle(0, 0, width, height), System.Drawing.Imaging.ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            
            for (int y = 0; y < height ; y++) {
                int* rowA = (int*)((byte*)dataA.Scan0 + (y * dataA.Stride));
                int* rowB = (int*)((byte*)dataB.Scan0 + (y * dataB.Stride));
                for (int x = 0; x < width; x++) {
                    if (rowA[x] != rowB[x]) {
                        return false;
                    }
                }
            }
            return true;
        } finally  {
            if(dataA != null) a.UnlockBits(dataA);
            if(dataB != null) b.UnlockBits(dataB);
        }
    }
