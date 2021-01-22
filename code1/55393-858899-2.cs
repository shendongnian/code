    using (OdbcConnection connection = 
               new OdbcConnection(connectionString))
    {
        int someNumber;
        int employeeID;
        OdbcDataReader dr = null;
        OdbcCommand selCmd = new OdbcCommand("SELECT EmployeeID, SomeNumber FROM Employees", connection);
        
        OdbcCommand updateCmd = new OdbcCommand("", connection);
        
        try
        {
            connection.Open();
            dr = selCmd.ExecuteReader();
            while(dr.Read())
            {
                employeeID = (int)dr[0];
                someNumber = (int)dr[1];
                updateCmd.CommandText = "UPDATE Employees SET SomeNumber= " + GetBusinessRule(someNumber) + " WHERE employeeID = " + employeeID;
                
                updateCmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
           // Don't forget to close the reader when we're done
           if(dr != null)
              dr.Close();
        }
        // The connection is automatically closed when the
        // code exits the using block.
    }
