    SqlConnection cn = new SqlConnection();
                SqlCommand cmd = new SqlCommand();
                cn.ConnectionString = "ConnectionString";
                List<string> str = new List<string>();
                cmd.Connection = cn;
                cmd.Connection.Open();
                cmd.CommandText = "SELECT code FROM employee WHERE Left = 'Y'";
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    str.Add(dr.GetValue(0).ToString());
                }
    
                foreach (string p in str)
                {
                    Console.WriteLine(p);
                }
