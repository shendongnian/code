    private void ListParms()
    {
        SqlConnection conn = new SqlConnection("my sql command string");
        SqlCommand cmd = new SqlCommand("proc name", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();
        SqlCommandBuilder.DeriveParameters(cmd);
        foreach (SqlParameter p in cmd.Parameters)
        {
           Console.WriteLine(p.ParameterName);
        }
    }
