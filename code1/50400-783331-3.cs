    public void AddToDatabase(IEnumerable<string> Words, int Good, int Bad, int Remove)
    {
        string sql = "INSERT INTO WordDef (Word, Good, Bad, Remove) VALUES (@Word, @Good, @Bad, @Remove)";
        using (OleDbConnection cn = new OleDbConnection("connection string here") )
        using (OleDbCommand cmd = new OleDbCommand(sql, cn))
        {
            cmd.Parameters.Add("@Word", OleDbType.VarChar);
            cmd.Parameters.Add("@Good", OleDbType.Integer).Value = Good;
            cmd.Parameters.Add("@Bad", OleDbType.Integer).Value = Bad;
            cmd.Parameters.Add("@Remove", OleDbType.Integer.Value = Remove;
            cn.Open();
            foreach (string word in Words)
            {
                cmd.Parameters[0].Value = word;
                cmd.ExecuteNonQuery();
            }
        }
    }
