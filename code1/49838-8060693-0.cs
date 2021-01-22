            //Change gridview to
            GridView1.AllowPaging = false;
            GridView1.DataBind();
             //Transfer rows from GridView to table
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    for (int j = 0; j < GridView1.Rows[0].Cells.Count; j++)
                    {
                          //Add your code here..
                    }
                }
            }
 
            //After filling your datatable change gridview paging style back to first, ie.
            
            GridView1.AllowPaging = true;
            GridView1.DataBind();
            This may help you, Cheers.....Let me know if this was helpful for you...
