    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Request.QueryString.HasKeys() || 
                    string.IsNullOrEmpty(Request.QueryString["m"]))
        {
            //return error or something relevant to your code
        }
        var m = Request.QueryString["m"];
    
        switch(m)
        {
            case "a":
            a();
            break;
            .....
            .....
        }
    }
