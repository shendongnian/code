    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                try
                {
                   
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                         e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
    
                    }                            
                }
                catch (Exception ex)
                {
    
                }
            }
