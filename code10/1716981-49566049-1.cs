    public partial class your_page : System.Web.UI.Page
    {
        public string _description;
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _description = "descriptor";
                ph1.DataBind();
            }
        }
    
        protected void btnUpdateDescription_Click(object sender, EventArgs e)
        {
            _description = "new description";
            ph1.DataBind();
        }
    }
