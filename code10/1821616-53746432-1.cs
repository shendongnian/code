    public List<string> approvedEmailDomains;
    protected void Page_Load(object sender, EventArgs e)
    {
        approvedEmailDomains = new List<string>()
        {
            "domainnameihid.com",
            "stackoverflow.com"
        };
    }
