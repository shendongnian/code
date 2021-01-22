    public string Id{
        get
        {
            return this.ViewState["Value"] == null ?
                0 :
                (int)this.ViewState["Value"];
        }
        set { this.ViewState["Value"] = value; }
    }
