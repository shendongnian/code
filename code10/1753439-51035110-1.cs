    public static void CreateNewEmployee(string FirstNamez, string LastNamez, int Pinz, string Departmentz)
         {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server = localhost\SQLEXPRESS; Database = Employee; Trusted_Connection = True;";
			SqlCommand cmd = new SqlCommand("spAddNewEmployee", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@FirstNamez", FirstNamez);
			cmd.Parameters.AddWithValue("@Lastnamez ", Lastnamez );
            cmd.Parameters.AddWithValue("@Pinz ", Pinz );
            cmd.Parameters.AddWithValue("@Departmentz ", Departmentz );
			con.Open();
			cmd.ExecuteReader();
			con.Close();
		
		}
