     using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionCS"].ConnectionString))
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO Visits(Name,Surname,DocType,DocNumber,Gender,Company,Delivery,Entrance,Visiting) VALUES(@Name,@Surname,@DocType,@DocNumber,@Gender,@Company,@Delivery,@Entrance,@Visiting)");
            using (SqlCommand com = new SqlCommand(sb.ToString(), con))
            {
                con.Open();
                com.Parameters.Add("@Name", SqlDbType.NVarChar).Value = NameBox.Text.Split(null)[0];
                //Add Other Parameter
                //...
                com.ExecuteScalar();
            }
        }
