    using (SqlConnection con = new SqlConnection('YOUR STRING CONNECTION'))
         {
            con.Open();
            string comando = "INSERT INTO LicenseDB (companie, software) VALUES ('" + lbGeneratedKeys.Items[0].ToString() + "','" + lbGeneratedKeys.Items[1].ToString() + "')";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = comando;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            
         }
