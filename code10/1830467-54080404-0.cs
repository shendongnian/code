    //Variable to hold the selected row count
    int selectedRows = 0;
    //iterate the rows
    for(int x = 0; x < DataGridView.Rows.Count; x++)
    {
       //iterate the cells
       for(int y = 0; y < DataGridView.Rows[x].Cells.Count; y++)
       {
            if(DataGridView.Rows[x].Cells[y] != null)
               if(DataGridView.Rows[x].Cells[y].Selected)
               {
                  //If a cell is selected consider it a selected row and break the inner for
                  selectedRows++;
                  break;
               }
       }
    
    
    }
