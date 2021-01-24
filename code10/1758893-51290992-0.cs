    static double Sum(double[,] paddedImage1, double[,] mask1, int startX, int startY)
    {
        double sum = 0;
        int maskWidth = mask1.GetLength(0);
        int maskHeight = mask1.GetLength(1);
        for (int y = startY; y < (startY + maskHeight); y++)
        {
            for (int x = startX; x < (startX + maskWidth); x++)
            {
                double img = paddedImage1[x, y];
                double msk = mask1[maskWidth - x + startX, maskHeight - y + startY];
                sum = sum + (img * msk);
            }
        }
        return sum;
    }
