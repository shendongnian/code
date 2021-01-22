    public SqlConnection CreateConnection()
    {
        var result = new SqlConnection("Your connection string here");
        result.Open();
        return result;
    }
