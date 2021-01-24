    public static string Func1()
    {
        using (SqlConnection con = new SqlConnection(ds.Tables[0].Rows[0][0].ToString()))
        {
            // My stuff here
        }
    }
