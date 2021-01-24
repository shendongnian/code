    ...
    using System.Threading.Tasks;
    namespace HeresANameSpace
    {
        class ThisIsAClass
        {
            public void HeresAMethod (string stp)
            {
                //GET STORED PROCEDURE HERE
                string conStr = @"Data Source=[server name]; Initial Catalog=[database name]; User ID=[my user ID]; Password=[my password]";
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = stp;
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
               }
                //End of HeresAMethod()
            }
            
            //End of HeresAClass
        }
        
        //End of HeresANamespace
    }
