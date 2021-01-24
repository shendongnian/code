    public static string Func1(string connectionString)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
                // My stuff here
        }
    }
