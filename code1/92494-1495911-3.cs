    public bool CheckAll()
    {
        for (int x = 0; x < _myBitmap.Width; x++)
        {
            for (int y = 0; y < _myBitmap.Height; y++)
            {
                if (CheckPixel(x, y))
                {
                    return true;
                }
            }
        }
        return false;
    }
