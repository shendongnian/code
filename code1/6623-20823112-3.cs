    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Services;
    using MySql.Data.MySqlClient;
     
    namespace SilverlightApplication1.Web
    {
        [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.ComponentModel.ToolboxItem(false)]
        public class WebService1 : System.Web.Services.WebService
        {
            string constr = "server=localhost;user=root;pwd=1234;database=test;";
    
            [WebMethod]
            public string ExecuteScalar(string sql)
            {
                try
                {
                    string result = "";
                    using (MySqlConnection conn = new MySqlConnection(constr))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            conn.Open();
                            cmd.Connection = conn;
                            cmd.CommandText = sql;
                            result = cmd.ExecuteScalar() + "";
                            conn.Close();
                        }
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
     
            [WebMethod]
            public string ExecuteNonQuery(string sql)
            {
                try
                {
                    long i = 0;
                    using (MySqlConnection conn = new MySqlConnection(constr))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            conn.Open();
                            cmd.Connection = conn;
                            cmd.CommandText = sql;
                            i = cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                    return i + " row(s) affected by the last command, no resultset returned.";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }  
        }
    } 
