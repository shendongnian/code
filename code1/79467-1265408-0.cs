    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    namespace AutomationApp
    {
        class Program
        {
            public void RunStoredProc()
            {
                Console.WriteLine("\nTop 10 Most Expensive Products:\n");
    
                using (SqlConnection conn = 
                    new SqlConnection(
                        "Server=(local);DataBase=master;IntegratedSecurity=SSPI"))
                {
                    conn.Open();
                    using (SqlCommand cmd = 
                          new SqlCommand("dbo.test", conn) {
                              CommandType = CommandType.StoredProcedure})
                    {
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                Console.WriteLine(String.Format("{0}, {1}",
                                                                rdr[0], rdr[1]));
                            }
                        }
                    }
                }
            }
        }
    }
