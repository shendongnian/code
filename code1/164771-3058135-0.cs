    protected object o
    {
        get {
            return ViewState["o"];
        }
        set {
            ViewState["o"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) { o = createObject(); }        
        Create_Table();
        if (Page.IsPostBack)
            Save_Data();
    }
