    private string guest 
    {
        get {return Session["consumer"].ToString();}
        set {Session["consume"] = value;}
    }
    protected void user_SelectedIndexChanged(object sender, EventArgs e)
    {
         user.text = guest;
    }
