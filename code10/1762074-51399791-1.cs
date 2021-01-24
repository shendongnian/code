    protected void Page_Load(object sender, EventArgs e)
    {     
       ClientScriptManager cs = Page.ClientScript;
       this.StartDate.Attributes.Add("onchange", cs.GetPostBackEventReference(this.StartDate, this.StartDate.ID));
    }
    protected void StartDate_ServerChange(object sender, EventArgs e)
    {
    
    }
