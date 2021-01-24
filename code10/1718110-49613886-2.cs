    public int AddNewCust(ref Models.Customer newCustomer)
    {
        var sql = "INSERT INTO CUSTOMER (Title, Forename, Surname, Address, PhoneNumber) VALUES (@Title, @Forename, @Surname, @Address, @PhoneNumber)";
        using(var command = new SqlCommand(sql))
        {
            command.Parameters.Add("@Title", SqlDbType.VarChar).Value = newCustomer.Title;
            command.Parameters.Add("@Forename", SqlDbType.VarChar).Value = newCustomer.Forename;
            command.Parameters.Add("@Surname", SqlDbType.VarChar).Value = newCustomer.Surname;
            //  fill in the rest of the parameters here...
            return ExecuteNonQuery(command); // change this method to return int...
        };
    }
