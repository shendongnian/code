    foreach(DataGridColumn col in vGrid.Columns)
    {
         col.Visible = false;
    }
        
    vGrid.Columns[0].Visible = true;
    vGrid.Columns[1].Visible = true;
