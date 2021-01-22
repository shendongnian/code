    using (OleDBConnection conn = new OleDBConnection(connstr))
    {
        while (IHaveData)
        {
            using (OldDBCommand cmd = new OldDBCommand())
            {
                cmd.Connection = conn;
                cmd.ExecuteScalar();
            }
        }
    }
