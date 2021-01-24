    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the row is a datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //cast the row back to a datarowview
            DataRowView row = e.Row.DataItem as DataRowView;
            //create a new cell
            TableCell cell = new TableCell();
            //create an image
            Image img = new Image();
            img.ImageUrl = row["imageUrl"].ToString();
            //add the image to the cell
            cell.Controls.Add(img);
            //add the cell to the gridview
            e.Row.Controls.Add(cell);
            //or use addat if you want to insert the cell at a certain index
            e.Row.Controls.AddAt(0, cell);
            //or don't add a new cell but add it to an existing one (replaces original content)
            e.Row.Cells[2].Controls.Add(img);
        }
    }
