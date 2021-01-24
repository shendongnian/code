    GridView gv = (GridView)sender;
     for (int i = 0; i < GridViewInput.Columns.Count; i++)
     {
      DataControlFieldCell cell = gv.Rows[e.RowIndex].Cells[i] as 
      DataControlFieldCell;
      gv.Columns[i].ExtractValuesFromCell(e.NewValues, cell, 
       DataControlRowState.Edit, true);
      }
