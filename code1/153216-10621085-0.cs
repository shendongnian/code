    private void AddParams(OleDbCommand cmd, params string[] cols)
    {
        //adding hectic (?) parameters
        foreach (string col in cols)
        {
            cmd.Parameters.Add("@" + col, OleDbType.Char, 0, col);
        }
    }
