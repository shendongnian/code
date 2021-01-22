    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using System.Configuration;
    
    namespace DAL
    {
        public class DBUtility
        {
            public static SqlConnection getconnection()
            {
            
               SqlConnection dbconnection = null;
                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["constr"];
                if(settings!=null)
                {
                    string str = settings.ConnectionString;
                    dbconnection = new SqlConnection(str);
                }
                return dbconnection;
            }
        }
    
    
    
    
          public int createasn(IShipmentBO objBO)
          {
              int ret = 0;
              SqlConnection conn = DBUtility.getconnection();
              conn.Open();
              SqlCommand cmd = new SqlCommand();
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.CommandText = "sp_CreateASN";
              cmd.Connection = conn;
              cmd.Parameters.AddWithValue("@POnumber", objBO.Ponum);
              cmd.Parameters.AddWithValue("@Unitsdelivered", objBO.Unitsdel);
              cmd.Parameters.AddWithValue("@Totalprice", objBO.Totalprice);
              cmd.Parameters.AddWithValue("@Expdeldate", objBO.Asnstatus);    
              ret = cmd.ExecuteNonQuery();
              conn.Close();
      
              return ret;
          }
    
    
    
    
    
    }
