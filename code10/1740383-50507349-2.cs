    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text.ToLower().IndexOf("actual") > -1)
                    {
                        e.Row.Cells[i].ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
