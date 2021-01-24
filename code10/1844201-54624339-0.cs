    public static void FlipTextureVertically(Texture2D original)
    {
        var originalPixels = original.GetPixels();
        Color[] newPixels = new Color[originalPixels.Length];
        int width = original.width;
        int rows = original.height;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                newPixels[x + y * width] = originalPixels[x + (rows - y -1) * width];
            }
        }
        original.SetPixels(newPixels);
        original.Apply();
    }
