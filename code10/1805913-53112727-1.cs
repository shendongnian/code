    int errorRowNumber = 0;
    
    private bool validateDataTableData(DataTable dt, string dtColumnName)
    {
        Boolean isTrue = false;
        foreach (DataRow r in dt.Rows)
        {
              if(!string.IsNullOrEmpty(r[dtColumnName].ToString()))
              {
                    isTrue = false;
                    errorRowNumber = dt.Rows.IndexOf(r) + 2;
                    break;
              }
        }
        return isTrue;
    }
 
