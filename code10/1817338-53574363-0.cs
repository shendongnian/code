    public static string LookupSubProfile (SubscriberProfileQuery subscriber)
    {
        try
        {
            var connString = "Server = Server\\SQLEXPRESS; initial catalog = Stuff; integrated security = True;";
    
            var query = "SELECT * FROM Subscriber WHERE SubscriberKey = @SubscriberKey";
    
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    // 2: add parameters
                    command.Parameters.Add("SubscriberKey", SqlDataType.VarChar).Value = suscriber.SuscriberKey;
                    // 1. use ExecuteScalar/ExecuteReader,
                    // you will need to define what exactly you need here
                    // 4. return the result
                    return (string)command.ExecuteScalar();
                }
                 // 3. remove unneeded calls
            }
    
            // 4. return null if nothing was found
            return null; 
        }
        catch
        {
            // 4: throw the error, log if possible
            throw;
        }
    }
