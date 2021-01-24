    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
             //add the boundfields here
        }
        //bind gridview on every postback
        gvDetails.DataSource = dt;
        gvDetails.DataBind();
    }
