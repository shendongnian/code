    public partial class _Default : System.Web.UI.Page
    {
        DataTable tb = new DataTable();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            DataTable dt = new DataTable("table");
            dt.Columns.Add(new DataColumn("NR", Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("Dihname", Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("ing", Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("Cost", Type.GetType("System.String")));
            Session["ss"] = dt;
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
             tb = (DataTable)Session["ss"];
             DataRow r1 = tb.NewRow();
             r1[0] = ViewState["dishid"].ToString();
             r1[1] = ViewState["dishname"];
             r1[3] = Label3.Text;
             tb.Rows.Add(r1);
             DataList5.DataSource = tb;
             DataList5.DataBind();
        }
    }
