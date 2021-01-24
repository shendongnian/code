    private string executescaler(string con, CommandType commandTyp, string procedure, SqlParameter[] sqlParameter)
    {
        string res;
        using (var connection = new SqlConnection(con))
        {
            using(var cmd = new SqlCommand(procedure, con))
            {
                cmd.CommandType = commandTyp;
                cmd.Parameters.AddRange(sqlParameter);
                connection.Open();
                res = cmd.ExecuteNonQuery().ToString();
            }
        }
        return res;
    }
