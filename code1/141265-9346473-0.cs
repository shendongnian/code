    public static long GetColumnNumber(string columnName)
    {
        int letterPos = 0;   
        long columnNumber = 0;
        for (int placeHolder = columnName.Length - 1; placeHolder >= 0; placeHolder--)
        {
            int currentSum = 1;
            for (int multiplier = 0; multiplier < placeHolder; multiplier++)
                currentSum *= 26;
            int letterValue = (int) columnName[letterPos];
            currentSum *= letterValue - 64;
            columnNumber += currentSum;
            if (letterPos != columnName.Length)
                letterPos++;
            //Console.WriteLine(((int)columnName[i]-64) + " = " + columnName[i]);
        }
            return columnNumber;
    }
