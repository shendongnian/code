    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            // Find the value in the c04_oprogrs column. You'll have to use
            // some trial and error here to find the right control. The line
            // below may provide the desired value but I'm not entirely sure.
            string value = e.Row.Cells[0].Text;
            // Next find the label in the template field.
            Label myLabel = (Label) e.Row.FindControl("myLabel");
            if (value == "1")
            {
                myLabel.Text = "Take";
            }
            else if (value == "2")
            {
                myLabel.Text = "Available";
            }
        }
    }
