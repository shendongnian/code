    private DateTime currentDate;
    private int extraCount;
    
    protected void grv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //assuming the cell with index 5 is the cell with the Date in it
            if (currentDate != DateTime.Parse(e.Row.Cells[5].Text))
            {
                //making a header row (so it looks different to the other rows)
                var row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                var headerCell = new TableHeaderCell();
                headerCell.ColumnSpan = 3; //however many columns you have in your gridview
                headerCell.Text = e.Row.Cells[5].Text;
                row.Cells.Add(headerCell);
                currentDate = DateTime.Parse(e.Row.Cells[5].Text);
                extraCount++;
                grvMortgages.Controls[0].Controls.AddAt(e.Row.RowIndex + extraCount, row);
            }
        }
    }
