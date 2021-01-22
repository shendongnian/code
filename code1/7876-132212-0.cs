    public WebProfile p = null;
    private readonly string Profile_Key = "CurrentUserProfile"; //Store this in a config or suchlike
    
    protected void Page_Load(object sender, EventArgs e)
    {
        p = GetProfile();
    
        if (!this.IsPostBack)
        {
            PopulateForm();
        }       
    }
    
    public static WebProfile GetWebProfile() {} // Unchanged
    
    private WebProfile GetProfile()
    {
        if (Session[Profile_Key] == null)
        {
            WebProfile wp = ProfileController.GetWebProfile();
            Session.Add(Profile_Key, wp);
        }
        else
            return (WebProfile)Session[Profile_Key];
    }
    
    [WebMethod]
    public MyWebMethod()
    {
        WebProfile wp = GetProfile();
        // Do what you need to do with the profile here
    }
