    if (e.Row.RowType == DataControlRowType.DataRow)
             {
                 // This line will get the reference to the underlying row
                 DataRowView _row = (DataRowView)e.Row.DataItem;
                 if (_row = null)
                 {
                   GridView1.Columns[0].Visible = false;
    }
    }
