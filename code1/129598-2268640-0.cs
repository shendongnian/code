        base.OnRowDataBound(e);
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
          for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                      TableCell cell = e.Row.Cells[i];
                      //read a bit more about cultures and formatting in .Net 
                      cell.Text = DateTime.Parse ( cell.Text, culture ); 
             }  
        }
        }
