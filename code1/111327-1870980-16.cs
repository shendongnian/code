    public void PopulatePixelValueMatrices(GenericImage image,int Width, int Height)
    {          
        uint [,] sums = this.sumOfPixelValues;
        ulong [,] squares = this.sumOfPixelValuesSquared;
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                Byte  pixelValue = image.GetPixelBlue(x, y);
                sums[y, x] += pixelValue;
                squares[y, x] += pixelValue * pixelValue;
            }
        }
    }
