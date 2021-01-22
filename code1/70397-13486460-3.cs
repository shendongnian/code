        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                TimePt.DataValueField = "TimePt";
                TimePt.DataTextField = "TimePt";
		        var times = TimePTDD.ToList();
		        times.Insert(0, new {TimePt="0",TimePt="--Select--"});
                TimePt.DataSource = times;
                TimePt.DataBind();
                //TimePt.SelectedIndex = 0;
            }
        }
