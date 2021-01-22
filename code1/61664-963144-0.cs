    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Label1.Text = DropDownList1.SelectedValue;
            }
        }
    
        protected void Page_Init(object sender, EventArgs e)
        {
            string[] number = { "first", "second", "third" };
            DropDownList1.DataSource = number;
            DropDownList1.DataBind();
        }
    }
