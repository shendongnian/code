    protected List<Control> ControlCache
    {
        get => (List<Control>)(Session["cachedControlsForPageX"] = (Session["cachedControlsForPageX"] as List<Control>) ?? new List<Control>());
        set => Session["cachedControlsForPageX"] = value;
    }
    /* If you can't use C# 7's expression bodied property accessors, here's the equivalent in blocks:
    protected List<Control> ControlCache
    {
        get { return (List<Control>)(Session["cachedControlsForPageX"] = (Session["cachedControlsForPageX"] as List<Control>) ?? new List<Control>()); }
        set { Session["cachedControlsForPageX"] = value; }
    }
    */
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            foreach (var control in ControlCache)
            {
                ContentPlaceHolder1.Controls.Add(control);
                ContentPlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"));
            }
        }
        else
            ControlCache = null;
    }
    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        while (myReader.Read())
        {
            TextBox txt = new TextBox();
            txt.Text = (string)myReader["idNumber"];
            txt.ID = "txt" + i;
            txt.ReadOnly = true;
            ContentPlaceHolder1.Controls.Add(txt);
            ContentPlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"));
            ControlCache.Add(txt);
            i++;
        }
    }
