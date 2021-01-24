    public Image TwoDimensionalArrayToImage(int[,] twoDimensionalArray)
    {
        var binaryFormatter = new BinaryFormatter();
        using(var memoryStream = new MemoryStream())
        {
            binaryFormatter.Serialize(memoryStream, twoDimensionalArray);
            return Image.FromStream(memoryStream);
        }
    }
