    // c# 
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int index = 0; // put the index of the column you need hide.
        e.Row.Cells[index].Visible = false;  
    }
