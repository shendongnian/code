    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            //Bind your drop downlist here
        }
    }
    
    
    
    protected void button1_Click(object sender, EventArgs e)
    {
        for(int x=0;x<ddl1.Items.Count;x++)
        {
            if(ddl1.Items[x].Selected)
            {
                //do something
            }
        }
    }
