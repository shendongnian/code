    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e) {
    
                if (e.SortExpression == SortField && SortDir != "desc") {
                    SortDir = "desc";
                }
                else {
                    SortDir = "asc";
                }
    
                SortField = e.SortExpression;
    
                DoDataBind();
            }
