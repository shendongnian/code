    [WebMethod]
    public String GetPONumber(string Database)
    {   
        //Create Object ready for Value
        object po = "";
        //Set Connection
        using(SqlConnection connection = new SqlConnection(GetConnString(Database)))
        {
            string Query = @" SQL QUERY GOES HERE!!!! ";
            using(SqlCommand command = new SqlCommand(Query, connection))
            {
                try
                {
                    connection.Open();
                    po = Command.ExecuteScalar();
                }
                catch
                {
                    //Error
                }
            }
        }
        return po.ToString();
    }
