    GridViewRow headerRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
    TableHeaderCell headerCell = new TableHeaderCell();
    headerCell.Text = "headercol1”;
    headerCell.ColumnSpan = 2;
    headerRow.Controls.Add(headerCell);
 
    headerCell = new TableHeaderCell();
    headerCell.ColumnSpan = 2;
    headerCell.Text = "headercol2”;
    headerRow.Controls.Add(headerCell);
    dataGridView2.HeaderRow.Parent.Controls.AddAt(0, headerRow); 
