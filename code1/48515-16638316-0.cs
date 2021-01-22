    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LocationIDHiddenField.Value = Request.QueryString["LocationID"];
        }
        if (LocationIDHiddenField.Value != null && LocationIDHiddenField.Value != string.Empty)
            LoadLocationParents();
    }
    private void LoadLocationParents()
    {
        long locationID = Convert.ToInt64(LocationIDHiddenField.Value);
        bool IsCurrent = true;
        HyperLink parent;        
        Label seperator;
        do
        {
            Basic.Location.LocationProperties location = Basic.Location.LocationLoader.GetLocationProperties(locationID);
            parent = new HyperLink();
            seperator = new Label();
            if (!IsCurrent)  
                parent.NavigateUrl = string.Format("LOCATIONLOV.aspx?LocationID={0}", location.LocationID);
            IsCurrent = false;
            parent.Text = location.LocationTitle;
            seperator.Text = "  >  ";
            ParentsPanel.Controls.AddAt(0, parent);
            ParentsPanel.Controls.AddAt(0, seperator);
            locationID = location.ParentID;     
        }
        while (locationID != 0);
        parent = new HyperLink();
        parent.NavigateUrl = "LOCATIONLOV.aspx";
        parent.Text = "upper nodes";
        ParentsPanel.Controls.AddAt(0, parent);
    }
