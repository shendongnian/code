    public void PopulatePixelValueMatrices(GenericImage image,int Width, int Height)
    {            
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                Byte  pixelValue = image.GetPixelBlue(x, y);
                this.sumOfPixelValues[x, y] += pixelValue;
                this.sumOfPixelValuesSquared[x, y] += pixelValue * pixelValue;
            }
        }
    }
