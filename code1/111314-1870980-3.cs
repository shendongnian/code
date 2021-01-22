    public void PopulatePixelValueMatrices(GenericImage image,int Width, int Height)
    {          
        int [,] sums = this.sumOfPixelValues;
        int [,] squares = this.sumOfPixelValuesSquared;
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                Byte  pixelValue = image.GetPixelBlue(x, y);
                sums[x, y] += pixelValue;
                squares[x, y] += pixelValue * pixelValue;
            }
        }
    }
