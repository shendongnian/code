    protected void Page_Load(object sender, EventArgs e)
    {
         if(!Page.IsPostBack) {
             string set = Request.QueryString["state"];
    
             Bond();
    
             ddl.Items.Insert(0, new ListItem(set));
          }
    }
