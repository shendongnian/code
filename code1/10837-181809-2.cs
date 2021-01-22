	public static string GetStandardExcelColumnName(int columnNumberOneBased)
	{
	  int baseValue = Convert.ToInt32('A');
	  int columnNumberZeroBased = columnNumberOneBased - 1;
	  
	  string ret = "";
	  if (columnNumberOneBased > 26)
	  {
		ret = GetStandardExcelColumnName(columnNumberZeroBased / 26) ;
	  }
	
	  return ret + Convert.ToChar(baseValue + (columnNumberZeroBased % 26) );
	}
