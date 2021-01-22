    protected void Page_Load(object sender, EventArgs e) 
    { 
        if (!Page.IsPostBack)
        {
          DirectoryInfo dir = new DirectoryInfo("..."); 
          FileInfo[] files = dir.GetFiles(); 
          GridView1.DataSource = files; 
          GridView1.DataBind(); 
        }
    }
