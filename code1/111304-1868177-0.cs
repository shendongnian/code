    public void PopulatePixelValueMatrices(GenericImage image,int Width, int Height)
    {            
            Byte pixelValue;
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    pixelValue = image.GetPixel(x, y).B;
                    this.sumOfPixelValues[x, y] += pixelValue;
                    this.sumOfPixelValuesSquared[x, y] += pixelValue * pixelValue;
                }
            }
    }
