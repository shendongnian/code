    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
           // Display the company name in italics.
           if(e.Row.Cells[1].Text.Equals("High") &&
              e.Row.Cells[2].Text.Equals("High"))
           {
               e.Row.BackColor = Color.FromName("Gray");
           }
           else if(e.Row.Cells[1].Text.Equals("High") &&
                   e.Row.Cells[2].Text.Equals("Low"))
           {
               e.Row.BackColor = Color.FromName("White");
           }
           else if(e.Row.Cells[1].Text.Equals("High") &&
                   e.Row.Cells[2].Text.Equals("Medium"))
           {
              e.Row.BackColor = Color.FromName("Gray"); 
           }
        }
    }
