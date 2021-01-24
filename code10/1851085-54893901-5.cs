    void OrderGridView_RowDataBound(Object sender, GridViewRowEventArgs e)
    {        
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            DateTime? dateValue = null;
            if(!DateTime.TryParse(e.Row.Cells[1].Text, out dateValue))
                e.Row.Cells[1].Text = dateValue.Value.ToString("MM/dd/yyyy");        
        }
    }
