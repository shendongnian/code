    private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      if(e.ColumnIndex == <columnIndex of IsSelected>)
      {
    	  string value = dgv[e.ColumnIndex, e.RowIndex].EditedFormattedValue;
    	   if( value == null || Convert.ToBoolean(value) == false)
    		  {
    		      //push false to employeeSelectionTable
    		  }
    	  else
    		  {
    			//push true to employeeSelectionTable
    		  }
    		
      }
    }
