    string[,] table = new string[30, 6];
        string previousValue = "placeholder";
        int xIndex = -1;
        int yIndex = 0;
        foreach (var value in groupedString)
        {
            if (table.GetLength(2))
            {
                 break;
            }
            if (value.Equals(previousValue) && table.GetLength(1) < yIndex)
            {
                yIndex += 1;
                table[xIndex, yIndex] = value;
            }
            else
            {
                xIndex += 1;
                yIndex = 0;
                table[xIndex, yIndex] = value;
            }
            previousValue = value;
        }
