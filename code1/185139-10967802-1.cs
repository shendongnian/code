    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable newsDataTable = new DataTable();
        // add some columns to our datatable
        newsDataTable.Columns.Add("href_li");
        newsDataTable.Columns.Add("DisplayText");
        for (int i = 1; i <= 5; i++)
        {
            DataRow newsDataRow = newsDataTable.NewRow();
            newsDataRow["href_li"] = "?sc=item_" + i;
            newsDataRow["DisplayText"] = "List Item # "+i;
            newsDataTable.Rows.Add(newsDataRow);
        }
        menu_ul_1.DataSource = newsDataTable;
        menu_ul_1.DataBind();
    }
