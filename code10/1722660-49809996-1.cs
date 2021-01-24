    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
     if (!string.IsNullOrEmpty(Session["MainPage"] as string) && Session["MainPage"].Tostring()=="true")
                {
    //proceed
    }
    else
    {
     Response.Redirect("mainpage.aspx");
    }
    }
