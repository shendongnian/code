    protected System.Web.UI.WebControls.DropDownList ddColor;
    
    private void Page_Load(object sender, System.EventArgs e)
    {
         if(!IsPostBack)
         {
            ddColor.DataSource = Enum.GetNames(typeof(Color));
            ddColor.DataBind();
         }
    }
