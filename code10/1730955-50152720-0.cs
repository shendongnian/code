    protected void lbCode_Click(object sender, EventArgs e)
    {
        GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
        GridView gv = clickedRow.NamingContainer as GridView;
        string lbCode = gv.DataKeys[clickedRow.RowIndex].Values[0].ToString();
    }
