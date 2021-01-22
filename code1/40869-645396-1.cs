    protected void Page_Load(object sender, EventArgs e)
    {
    	Dictionary<string, string> dictionary = new Dictionary<string, string>()
    	{
    		{"a", "aaa"},
    		{"b", "bbb"},
    		{"c", "ccc"}
    	};
    	datalist.DataSource = dictionary;
    	datalist.DataBind();
    
    	for (int i = 0; i < datalist.Items.Count; i++)
    	{
    		Response.Write(string.Format("datalist.DataKeys[{0}] = {1}<br />", i, datalist.DataKeys[i]));
    	}
    }
