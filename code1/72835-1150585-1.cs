    public string MyPageProperty 
	{
		get { return _myPageProperty; }
		set { _myPageProperty = value; }
	}
    protected void Page_Load(object sender, EventArgs e)
    {
		MyPageProperty = "This is some data";
    }
