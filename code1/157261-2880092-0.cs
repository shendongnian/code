    public static SqlConnection DBConn
    {
        get
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["BAR"].ConnectionString);
        }
    }
