    StringBuilder builder = new StringBuilder();
    int row, column;
    for (row = 0; row <= 6; row++)
    {
        for (column = 0; column <= 6; column++)
        {
            if ((column == 1 && row != 0 && row != 6) ||
                ((row == 0 || row == 6) && column > 1 && column < 5) ||
                    (row == 3 && column > 2 && column < 6) ||
                    (column == 5 && row != 0 && row != 2 && row != 6))
                builder.Append("*");
            else
                builder.Append(" ");
        }
        builder.Append(Environment.NewLine);
    }
    builder.Append(Environment.NewLine);
    string text = builder.ToString();
