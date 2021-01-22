    public string Title
    {
        get
        {  
            return this.lblTitle.Text;
        }
        set
        {
            this.lblTitle.Text = value;
        }
    }
    public string TitleFormat
    {
        get
        {  
            if(ViewState["TitleFormat"] != null)
                return ViewState["TitleFormat"].ToString();
            return string.Empty;
        }
        set
        {
            ViewState["TitleFormat"] = value;
        }
    }
 
    public void Page_PreRender(object sender, EventArgs e)
    {
        if(!string.IsNullOrEmpty(this.TitleFormat))
        {
            this.lblTitle.Text = string.Format("{0}, {1}", this.lblTitle.Text, this.TitleFormat)
        }
    }
