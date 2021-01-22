    private string myTitle;
    protected string MyTitle
    {
       get { return myTitle; }
       set { myTitle = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        MyTitle = "Testing 123!";
    }
