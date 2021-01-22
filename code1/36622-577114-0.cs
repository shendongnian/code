    Dictionary<string, string> d;
    protected void Page_Load(object sender, EventArgs e)
    {
    d = new Dictionary<string, string>();
    d.Add("key 1", 1);
    d.Add("key 2", 2);
    d.Add("key 3", 3);
    d.Add("key 4", 4);
    d.Add("key 5", 5);
    
    GridView1.DataSource = d;
    GridView1.DataBind();
    
    }
