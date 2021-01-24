    public static void CreateNewEmployee(string FirstNamez, string LastNamez, int Pinz, string Departmentz)
    {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = @"Server = localhost\SQLEXPRESS; Database = Employee; Trusted_Connection = True;";
    
        SqlCommand command = new SqlCommand();
    
        using (connection)
        {
            connection.Open();
            string commandtext = "INSERT INTO dbo.EmployeeDatabase (FirstName, LastName, PIN, Department) VALUES (@FirstNamez, @Lastnamez, @Pinz, @Departmentz);";
    
            command.CommandText = commandtext;
            command.Connection = connection;
            // define the parameters and set their values!
            command.Parameters.Add("@FirstNamez", SqlDbType.VarChar, 100).Value = FirstNamez;
            command.Parameters.Add("@LastNamez", SqlDbType.VarChar, 100).Value = LastNamez;
            command.Parameters.Add("@Pinz", SqlDbType.Int).Value = Pinz;
            command.Parameters.Add("@Departmentz", SqlDbType.VarChar, 100).Value = Departmentz;
    
            command.ExecuteNonQuery();
        }
    }
