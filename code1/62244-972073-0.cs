    protected void Page_Load(object sender, EventArgs e)
    {
       if (!Page.IsPostback)
       {
           List<string> list = new List<string>();
           list.Add("Teststring");
           bindMydatagrid(list);
       }
    }
    protected void bindMydatagrid(List<string> list)
    {
        gv.DataSource = list;
        gv.DataBind();
    }
