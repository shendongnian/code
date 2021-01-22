    public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    ListView1.DataSource = new List<int>() { 1, 2, 3 };
                    ListView1.DataBind();
                }
            }
    
            public void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
            {
                if (e.CommandName == "Select")
                {
                    var isGoingUp = (e.CommandArgument.ToString() == "Up");
                }
            }
    
            protected void ListView1_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
            {
                this.ListView1.SelectedIndex = e.NewSelectedIndex;
    
    
                ListView1.DataSource = new List<int>() { 1, 2, 3 };
                ListView1.DataBind();
            }
        }
