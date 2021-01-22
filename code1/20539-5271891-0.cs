    public static String getColumnNameFromIndex(int column)
    {
        column--;
        String col = Convert.ToString((char)('A' + (column % 26)));
        while (column >= 26)
        {
            column = (column / 26) -1;
            col = Convert.ToString((char)('A' + (column % 26))) + col;
        }
        return col;
    }
