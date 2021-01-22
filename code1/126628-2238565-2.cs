    protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Get your QueryString variable
                if (Request["YourVariable"] != null)
                {
                 string yourVariable = Request["YourVariable"].ToString();
                  if (yourVariable == "CategoryX") {
                       ObjectDataSource1.SelectMethod = "SelectMethodFromCategoryX";
                 
                       // and if you need to set SelectParameters to your ObjectDataSource
                       ObjectDataSource1.SelectParameters["pYourParameterNameForCategoryX"].DefaultValue = this.txtTest.Text;
                  }
                }
            }
        }
 
