    string Query= string.Empty;
    string SortExpression = string.Empty;
    
    // HDFSort is an HiddenField !!!
    
    protected void SortCommand_OnClick(object sender, GridViewSortEventArgs e)
    {
       SortExpression = e.SortExpression; 
       Query = YourQuery + " ORDER BY "+SortExpression +" "+ HDFSort.Value ;
       HDFSort.Value = HDFSort.Value== "ASC" ? "DESC" : "ASC";
       RefreshGridView();
    }
    
    protected void RefreshGridView()
    {
       GridView1.DataSource = DBObject.GetData(Query);
       GridView1.DataBind();
    }
