    public void CreateRuntime_Table()
    {
        int tblRows = int.Parse(txtrow.Text);
        int tblCols = int.Parse(txtcol.Text);
        //I would recommend using int.TryParse with some defaults
        int colSpan = 0;
        int rowSpan = 0;
        int.TryParse(tbColspanName.Text, out colSpan);
        int.TryParse(tbRowspanName.Text, out rowSpan);
        Table tbl = new Table();
        tbl.BorderWidth = 3;
        tbl.BorderStyle = BorderStyle.Solid;
        tbl.ID = "myTable";
        for (int i = 1; i <= tblRows; i++)
        {
            TableRow tr = new TableRow();
            for (int j = 1; j <= tblCols; j++)
            {
                TableCell tc = new TableCell()
                {
                    //assign entered col / row span
                    ColumnSpan = colSpan,
                    RowSpan = rowSpan
                };
                TextBox txtbox = new TextBox();
                txtbox.Text = "Test Row:" + i + "Test Col:" + " " + j;
                //Add the control to the table cell
                tc.Controls.Add(txtbox);
                tr.Controls.Add(tc);
            }
            tbl.Rows.Add(tr);
        }
        form1.Controls.Add(tbl);
    }
