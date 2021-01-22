        public partial class _Default : System.Web.UI.Page
    {
        ArrayList array;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["array"] == null)
            {
                array = new ArrayList();
                Session.Add("array", array);
            }
            else
                array = Session["array"] as ArrayList;
            GridView1.DataSource = array; 
            GridView1.DataBind(); //Edit 2
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            array.Add(DateTime.Now);
        }
    }
