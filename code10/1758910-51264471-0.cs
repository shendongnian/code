     namespace loginwebservice
    {
        /// <summary>
        /// Summary description for Service1
        /// </summary>
        [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.ComponentModel.ToolboxItem(false)]
        // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
        // [System.Web.Script.Services.ScriptService]
        public class Service1 : System.Web.Services.WebService
        {
            string cn = ConfigurationManager.ConnectionStrings["UserDataManager"].ToString();
            
            [WebMethod]
            public DataSet login(string uname, string pwd)
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from user where user_name = '" + uname + "' and user_password='" + pwd + "' ;",cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
    }
