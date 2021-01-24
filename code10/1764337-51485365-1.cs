    public DataTable  SliceTable(this DataTable dt, int rowsCount, int skipRows=0)
    {
         DataTable dtResult = dt.Clone();
         for (int i = skipRows; i < dt.Rows.Count && rowsCount > 0; i++)
         {
             dtResult.ImportRow(dt.Rows[i]);
             rowsCount --;
         }
    
         return dtResult;
    }
 
