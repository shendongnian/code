    protected void Page_Load(object sender, EventArgs e)
    {
        //not here
        TrackerGrid.DataSource = source;
        TrackerGrid.DataBind();
        if (IsPostBack == false)
        {
            //but inside an ispostback check
            TrackerGrid.DataSource = source;
            TrackerGrid.DataBind();
        }
    }
