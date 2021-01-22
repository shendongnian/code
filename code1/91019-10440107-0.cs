    protected void GV_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV.PageIndex = e.NewPageIndex;
        BindGrid();
    }
        public override void BindGrid()
    {
        query = new CommonQueries();
        GV.DataSource = query.getAllBooks();
        GV.DataBind();
    }
