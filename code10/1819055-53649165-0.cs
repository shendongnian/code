    public MasterPage master;
    protected void Page_Load(object sender, EventArgs e)
    {
        master = (MasterPage)Page.Master;
        string s = master.Base64ForUrlEncode("test");
    }
