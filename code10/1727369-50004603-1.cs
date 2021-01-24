    public static Dictionary<string, List<object>> GetAllData(string command, SqlParameter[] pars, SqlConnection conn)
    {
        var res = new Dictionary<string, List<object>>();
        using (var cmd = new SqlCommand(command, conn))
        {
            cmd.Parameters.AddRange(pars);
            using (var reader = cmd.ExecuteReader())
            {
              //...
              return res;
            }
        }
    }
