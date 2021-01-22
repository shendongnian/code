    void PopulateNewsItems (int? pageNo)
    {
        var model = ModelFactory.GetNewsModel ();
        var searchResults = model.GetNewsItems ();
        var dataSource = new PagedDataSource ();
        dataSource.DataSource = new List<NewsItem> (searchResults);
        dataSource.AllowPaging = true;
        var pageSizeFromConfig = ConfigurationManager.AppSettings["NewsItemsPageCount"];
        var pageSize = 10;
        int.TryParse (pageSizeFromConfig, out pageSize);
        dataSource.PageSize = pageSize;
        dataSource.CurrentPageIndex = pageNo ?? 0;
        PagingPanel.Controls.Clear ();
        for (var i = 0; i < dataSource.PageCount; i++)
        {
	    var linkButton = new LinkButton ();
            linkButton.CommandArgument = i.ToString ();
            linkButton.CommandName = "PageNo";
            linkButton.Command += NavigationCommand;
            linkButton.ID = string.Format ("PageNo{0}LinkButton", i);
            if (pageNo == i || (pageNo == null && i == 0))
            {
                linkButton.Enabled = false;
                linkButton.CssClass = "SelectedPageLink";
            }
            linkButton.Text = (i + 1).ToString ();
            PagingPanel.Controls.Add (linkButton);
            if (i < (dataSource.PageCount - 1))
                PagingPanel.Controls.Add (new LiteralControl ("|"));
        }
        NewsRepeater.DataSource = dataSource;
        NewsRepeater.DataBind ();
    }
