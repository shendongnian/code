    if (e.Row.RowType == DataControlRowType.DataRow)
    {
      string val = Convert.ToString(e.Row.Cells[0]);  //check first cell value
      if(string.IsNullorEmpty(val) )             
      {
         gv.Columns[0].Visible = false;     //Hides First Column
      }
    }
