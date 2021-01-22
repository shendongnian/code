    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void ListPager_PreRender(object sender, EventArgs e)
    {
        MyList.DataSource = GetSomeList();
        MyList.DataBind();    
    }
