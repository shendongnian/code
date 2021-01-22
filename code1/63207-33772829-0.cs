    private class CustomException : ScriptException
    {
      public CustomException()
      {
      }
    }
    
    try
    {
    	foreach(DataGridViewRow row in grid.Rows)
    	{
    		foreach(DataGridViewCell cell in row.Cells)
    		{
    			if(cell.Value == myValue)
    			    throw new CustomException();
    		}
    	}
    }
    catch(CustomException)
    { }
