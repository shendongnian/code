        using System.Web.UI.WebControls;
    using System.Web.Services;
    using System.Data;
    using System.Text;
    using System.Web.Script.Serialization;
    using System.Web.Script.Services;
    using System.Collections;
    using System.Data.SqlClient;
    
    public partial class orderSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e){}
    
    
        [WebMethod]
        public static string SendMessage(string order)
        {
                string Server = "alyeyey";
                string Username = "apjsjsjs";
                string Password = "jjsjsjs";
                string Database = "Amhshshs";
    
                string ConnectionString = "Data Source=" + Server + ";";
                ConnectionString += "User ID=" + Username + ";";
                ConnectionString += "Password=" + Password + ";";
                ConnectionString += "Initial Catalog=" + Database;
                string query = "select * from optionsRelation where orderNumber = " + order;//+" OR orderNumber = 17";
    
                DataTable dt = new DataTable();
    
                Hashtable sendData = new Hashtable();
    
            try
                {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        dt.Load(dr);
                    }
                }
    
                //Creating StringBuilder array for storing keys
                StringBuilder[] empKeys = new StringBuilder[4];
    
                for (int i = 0; i < empKeys.Length; i++)
                {
                    empKeys[i] = new StringBuilder();
                }
    
                //Creating stringbuilder array for storing key values
                StringBuilder[] empDetails = new StringBuilder[4];
    
                for (int i = 0; i < empDetails.Length; i++)
                {
                    empDetails[i] = new StringBuilder();
                }
    
                //putting datatable data to Keys array i-e empKeys and Values array i-e empDetails array
                int inc = 0;
                int j = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {
                        empKeys[inc].Append(dc.ColumnName);
                        inc++;
                    }
                    foreach (DataColumn dc in dt.Columns)
                    {
                        empDetails[j].Append(dr[dc]);
                        j++;
                    }
                }
    
                //mapping keys array and values array in hashtable
    
                for (int k = 0; k < empKeys.Length; k++)
                {
                    sendData.Add(empKeys[k].ToString(), empDetails[k].ToString());
                }
                //sendData.Add("orderNum", order);
                JavaScriptSerializer jss = new JavaScriptSerializer();
                string output = jss.Serialize(sendData);
                return output;
            }
            catch (Exception ex)
            {
                return ex.Message + "-" + ex.StackTrace;
            }
        }
    }
