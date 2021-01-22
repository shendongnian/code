    public WebProfile p = null;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        p = ProfileController.GetWebProfile();
        if (!this.IsPostBack)
        {
             PopulateForm();
        }       
    }
    
    public static WebProfile GetWebProfile()
    {
        //get shopperID from cookie
        string mscsShopperID = GetShopperID();
        string userName = new tpw.Shopper(Shopper.Columns.ShopperId,        mscsShopperID).Email;
        return WebProfile.GetProfile(userName); 
    }
