    string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=c:\\PathTo\\Your_Database_Name.mdb; User Id=admin; Password=";
    using (OdbcConnection connection = 
               new OdbcConnection(connectionString))
    {
        // Suppose you wanted to update the Salary column in a table
        // called Employees
        string sqlQuery = "UPDATE Employees SET Salary = Salary * Factor";
        OdbcCommand command = new OdbcCommand(sqlQuery, connection);
        
        try
        {
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        // The connection is automatically closed when the
        // code exits the using block.
    }
