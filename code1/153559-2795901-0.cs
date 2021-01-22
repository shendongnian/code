    int[,] iMap = new int[iMapHeight, iMapWidth];
    using (var reader = new StreamReader(fileName))
    {
        for (int i = 0; i < iMapHeight; i++)
        {
            string line = reader.ReadLine();
            for(int j = 0; i < iMapWidth; j++)
            {
                iMap[i, j] = (int)(line[j] - '0');
            }
        }
    }
