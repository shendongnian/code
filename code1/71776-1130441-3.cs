    protected void Page_Load(object sender, EventArgs e)
    {
        //Binding code moved from Page_Load
        //to the ListView's PreRender event
    }
    protected void ListPager_PreRender(object sender, EventArgs e)
    {
        MyList.DataSource = GetSomeList();
        MyList.DataBind();    
    }
