    public DataTable  SliceTable(this DataTable dt, int rowsCount, int skipRows=0)
    {
         DataTable dtResult = dt.Clone();
         for (int i = skipRows; i < dt.Rows.Count; i++)
         {
             dtResult.ImportRow(dt.Rows[i]);
         }
    
         return dtResult;
    }
 
