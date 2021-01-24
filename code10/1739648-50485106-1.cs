    int prevSum = -1;
    for (int col = 0; col < table.GetLength(0); ++col)
    {
        int sum = CountRow(table, col);
        Debug.Log("table column :" + col + " has " + sum + " data");
        if (sum == prevSum)
        {
           //comparison happens
        }
    }
