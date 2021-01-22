    public static string GetStandardExcelColumnName(int columnNumberOneBased)
    {
      int baseValue = Convert.ToInt32('A') - 1;
      string ret = "";
        
      if (columnNumberOneBased > 26)
      {
      	ret = GetStandardExcelColumnName(columnNumberOneBased / 26);
      }
    
      return ret + Convert.ToChar(baseValue + (columnNumberOneBased % 26));
    }
