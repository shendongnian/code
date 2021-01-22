    // add checkboxes
    DataGridViewCheckBoxColumn col_chkbox = new DataGridViewCheckBoxColumn();
    {
        col_chkbox.HeaderText = "X";
        col_chkbox.Name = "checked";
        col_chkbox.CellTemplate = new DataGridViewCheckboxCellFilter();                
    }
    this.Columns.Add(col_chkbox);
