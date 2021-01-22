    protected void Page_Load(object sender, EventArgs e)
    {
    	if (!IsPostBack)
    	{
    		txtStartDate.Attributes.Add("readonly", "readonly");
    		txtEndDate.Attributes.Add("readonly", "readonly");
    	}
    }
