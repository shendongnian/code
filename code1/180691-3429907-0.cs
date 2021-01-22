    protected void Page_Load(object sender, System.EventArgs e)
    {
        string[] locations = new string[] {
            "Las Vegas",
            "Los Angeles",
            "Tampa",
            "New York",
            "s",
            "sss"
        };
        
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        string jsArray = serializer.Serialize(locations);
        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "locations", jsArray, true);
    }
        
