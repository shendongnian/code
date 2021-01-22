    private void BindRpt()
    {
        PagedDataSource ObjPds;
        ObjPds = DoPagging((DataTable)ViewState["dtblProducts"]);
        dlProducts.DataSourceID = "";
        dlProducts.DataSource = ObjPds;
        dlProducts.DataBind();
    }
    protected PagedDataSource DoPagging(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            lblNoRecord.Visible = false;
            pnlNavigation.Visible = true;
            pnlTopNavigation.Visible = true;
        }
        else
        {
            lblNoRecord.Visible = true;
            pnlNavigation.Visible = false;
            pnlTopNavigation.Visible = false;
        }
        PagedDataSource ObjPagDataSource = new PagedDataSource(); //'declares the paged data source
        ObjPagDataSource.DataSource = dt.DefaultView;
        ObjPagDataSource.AllowPaging = true;
        ObjPagDataSource.PageSize = PgSize;
        if (hdfPageIndex.Value == "SetLastPageIndex")
        {
            CurrentPageIndx = ObjPagDataSource.PageCount - 1;
            ObjPagDataSource.CurrentPageIndex = ObjPagDataSource.PageCount - 1;
        }
        else
        {
            ObjPagDataSource.CurrentPageIndex = CurrentPageIndx; 
        }
        if (ObjPagDataSource.PageCount > 1)
        {
            if (ObjPagDataSource.IsFirstPage == true)
            {
                ibtnLast.Enabled = true;
                ibtnFirst.Enabled = false;
                ibtnPrevious.Enabled = false;  
                ibtnNext.Enabled = true;
                ibtnLastTop.Enabled = true;
                ibtnFirstTop.Enabled = false;
                ibtnPreviousTop.Enabled = false;
                ibtnNextTop.Enabled = true;
            }
            else if (ObjPagDataSource.IsLastPage == true)
            {
                ibtnFirst.Enabled = true;
                ibtnLast.Enabled = false;
                ibtnNext.Enabled = false;
                ibtnPrevious.Enabled = true;
                ibtnFirstTop.Enabled = true;
                ibtnLastTop.Enabled = false;
                ibtnNextTop.Enabled = false;
                ibtnPreviousTop.Enabled = true;
            }
            else
            {
                ibtnFirst.Enabled = true;
                ibtnPrevious.Enabled = true;
                ibtnNext.Enabled = true;
                ibtnLast.Enabled = true;
                ibtnFirstTop.Enabled = true;
                ibtnPreviousTop.Enabled = true;
                ibtnNextTop.Enabled = true;
                ibtnLastTop.Enabled = true;
            }
        }
        else
        {
            ibtnFirst.Enabled = false;
            ibtnLast.Enabled = false;
            ibtnPrevious.Enabled = false;
            ibtnNext.Enabled = false;
            ibtnFirstTop.Enabled = false;
            ibtnLastTop.Enabled = false;
            ibtnPreviousTop.Enabled = false;
            ibtnNextTop.Enabled = false;
        }
        return ObjPagDataSource;
    }
    public int CurrentPageIndx
    {
        get
        {
            System.Object o = this.ViewState["_CurrentPageIndx"];
            if (o == null)
                return 0;
            else
                return Convert.ToInt32(o);
        }
        set
        {
            ViewState["_CurrentPageIndx"] = value;
        }
    }
   
    protected void ibtnFirst_Click(object sender, ImageClickEventArgs e)
    {
        hdfPageIndex.Value = "";
        CurrentPageIndx = 0;
        BindRpt();
    }
    protected void ibtnPrevious_Click(object sender, ImageClickEventArgs e)
    {
        hdfPageIndex.Value = "";
        CurrentPageIndx = CurrentPageIndx - 1;
        BindRpt();
    }
    protected void ibtnNext_Click(object sender, ImageClickEventArgs e)
    {
        hdfPageIndex.Value = "";
        CurrentPageIndx = CurrentPageIndx + 1;
        BindRpt();
    }
    protected void ibtnLast_Click(object sender, ImageClickEventArgs e)
    {
        hdfPageIndex.Value = "SetLastPageIndex";
        BindRpt();
    }
