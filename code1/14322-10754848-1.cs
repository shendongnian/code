    /*Do this in a loop for each header cell so Cells[0] to cells[however many] and however long the string is so use length properties to get the actual length of the text string */ 
    
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
            {
             StringBuilder vtxt = new StringBuilder();
                vtxt.Append(GridView1.HeaderRow.Cells[0].Text.ToString().Substring(0,1));
                vtxt.Append("<br />");
                vtxt.Append(GridView1.HeaderRow.Cells[0].Text.ToString().Substring(1, 1));
                vtxt.Append("<br />");
                vtxt.Append(GridView1.HeaderRow.Cells[0].Text.ToString().Substring(2, 1));
                vtxt.Append("<br />");
                vtxt.Append(GridView1.HeaderRow.Cells[0].Text.ToString().Substring(3, 1));
                vtxt.Append("<br />");
                vtxt.Append(GridView1.HeaderRow.Cells[0].Text.ToString().Substring(4, 1));
                vtxt.Append("<br />");
                vtxt.Append(GridView1.HeaderRow.Cells[0].Text.ToString().Substring(5, 1));
                vtxt.Append("<br />");
                vtxt.Append(GridView1.HeaderRow.Cells[0].Text.ToString().Substring(6, 1));
                vtxt.Append("<br />");
                vtxt.Append(GridView1.HeaderRow.Cells[0].Text.ToString().Substring(7, 1));
    
                GridView1.HeaderRow.Cells[2].Text = vtxt.ToString();
            }
