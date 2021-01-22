    private void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if(locationsColumn.Index == e.ColumnIndex)
        {
            DataGridViewComboBoxCell subLocationCell = 
                (DataGridViewComboBoxCell)(grid.Rows[e.RowIndex].Cells["subLocationsColumn"]);
    
            string location = grid[e.ColumnIndex, e.RowIndex].Value as String;
    
            switch (location)
            {
                case "Location A":
                    subLocationCell.DataSource = new string[] {
                        "A sublocation 1",
                        "A sublocation 2",
                        "A sublocation 3" 
                    };
                    break;
                case "Location B":
                    subLocationCell.DataSource = new string[] { 
                        "B sublocation 1",
                        "B sublocation 2",
                        "B sublocation 3" 
                    };
                    break;
                default:
                    subLocationCell.DataSource = null;
                    return;
            }
        }
    }
