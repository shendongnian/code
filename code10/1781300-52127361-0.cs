    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItem != null)
            {
                // Set the capacity label text
                Label1.Text = e.Row.Cells[0].Text;
    
    
                // Calc the sum of all of the row values
                int sum = 0;
                foreach(TableCell c in e.Row.Cells)
                {
                      sum+= Int32.Parse(c.Text);
                }
    
    
                // Set the sum label text value
                Label2.Text = sum.ToString();        }
        }
