        #region Dataset -> Immediate Window
    public static void printTbl(DataSet myDataset)
    {
        printTbl(myDataset.Tables[0]);
    }
    public static void printTbl(DataTable mytable)
    {
        for (int i = 0; i < mytable.Columns.Count; i++)
        {
            Debug.Write(mytable.Columns[i].ToString() + " | ");
        }
        Debug.Write(Environment.NewLine + "=======" + Environment.NewLine);
        for (int rrr = 0; rrr < mytable.Rows.Count; rrr++)
        {
            for (int ccc = 0; ccc < mytable.Columns.Count; ccc++)
            {
                Debug.Write(mytable.Rows[rrr][ccc] + " | ");
            }
            Debug.Write(Environment.NewLine);
        }
    }
    public static void ResponsePrintTbl(DataTable mytable)
    {
        for (int i = 0; i < mytable.Columns.Count; i++)
        {
            HttpContext.Current.Response.Write(mytable.Columns[i].ToString() + " | ");
        }
        HttpContext.Current.Response.Write("<BR>" + "=======" + "<BR>");
        for (int rrr = 0; rrr < mytable.Rows.Count; rrr++)
        {
            for (int ccc = 0; ccc < mytable.Columns.Count; ccc++)
            {
                HttpContext.Current.Response.Write(mytable.Rows[rrr][ccc] + " | ");
            }
            HttpContext.Current.Response.Write("<BR>");
        }
    }
    public static void printTblRow(DataSet myDataset, int RowNum)
    {
        printTblRow(myDataset.Tables[0], RowNum);
    }
    public static void printTblRow(DataTable mytable, int RowNum)
    {
        for (int ccc = 0; ccc < mytable.Columns.Count; ccc++)
        {
            Debug.Write(mytable.Columns[ccc].ToString() + " : ");
            Debug.Write(mytable.Rows[RowNum][ccc]);
            Debug.Write(Environment.NewLine);
        }
    }
    #endregion
