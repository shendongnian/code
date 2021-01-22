    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    namespace DAL
    {
        public static class DAL
        {
            public static SqlConnection conn;
    
            static DAL()
            {
    
    
                conn = new SqlConnection(ConfigurationManager.AppSettings["conStr"].ToString());
                conn.Open();
    
    
            }
    
    
        }
    }
