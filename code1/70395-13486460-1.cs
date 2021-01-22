    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            TimePt.DataValueField = "TimePt";
            TimePt.DataTextField = "TimePt";
            TimePt.DataSource = TimePTDD.ToList();
    		TimePt.Items.Insert(0, new {TimePt = "0",TimePt = "--Select--"});
            TimePt.DataBind();
            //TimePt.SelectedIndex = 0;
        }
    }
