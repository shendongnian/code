    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //here the Cells is an array where you can pass the index value of the cell where you want to check and if you don't know where the value is then you can do a for loop and then check the value
                if (e.Row.Cells[0].Text == "someValue")
                {
                    e.Row.Cells[0].ForeColor = System.Drawing.Color.Red;
                }
            }
        }
