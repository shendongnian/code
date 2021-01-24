    public partial class DisplayGrid : System.Web.UI.Page
    {
        string strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["PostbankConnectionString"].ConnectionString;
        string query = "SELECT * FROM tbl_user";
    
        protected void Page_Load(object sender, EventArgs e)
        {
            //query 
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
    
            SqlDataReader reader;
            con.Open();
            reader = cmd.ExecuteReader();
               GridView1.DataSource = reader;
               //Bind the data
                GridView1.DataBind();
                reader.Close();
            con.Close();
        }
    }
