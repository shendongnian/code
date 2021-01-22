    public partial class _Default : System.Web.UI.Page
    {
      List<object> TestBindingList;
      protected void Page_Load(object sender, EventArgs e)
      {
        if (!IsPostBack)
        {
            TestBindingList = new List<object>();
            TestBindingList.Add(new { id = 1, name = "Test Name 1" });
            TestBindingList.Add(new { id = 2, name = "Test Name 2" });
            TestBindingList.Add(new { id = 3, name = "Test Name 3" });
            this.GridView1.DataSource = TestBindingList;
            this.GridView1.DataBind();
        }
      }
      protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
      {         
        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            this.Label1.Text = this.GridView1.DataKeys[index]["id"].ToString();
        }
      }
    }
