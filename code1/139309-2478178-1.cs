    protected void checkGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Button moveButton = (Button)e.Row.Cells[9].Controls[1];            
            moveButton.Attributes.Add("onclick","someJavaScript('"+moveButton.ClientID+"');");
        }
    }
