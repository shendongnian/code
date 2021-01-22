    using GainItem = KeyValuePair<string, int>;
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<GainItem> dic = new List<GainItem>();
                dic.Add(new GainItem("First", 1));
                dic.Add(new GainItem("Second", 2));
                dic.Add(new GainItem("Fourth", 4));
                ddl.DataSource = dic;
                ddl.DataBind();
            }
        }
        protected void btn_Click(object sender, EventArgs e)
        {
            Response.Write(ddl.SelectedValue);
        }
    }
