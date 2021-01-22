    protected void execute(String sql, params object[] args)
    {
        for (int i = 0; i < args.Count(); i++ )
        {
            sql = sql.Replace(String.Format("{{{0}}}", i), args[i].ToString());
        }
        //...
    }
