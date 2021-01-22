    public static class With
    {
        public static void Transaction( ISession s, Action proc )
        {
            using( ITransaction thx = s.BeginTransaction () )
            {
                try
                {
                    proc();
                    thx.Commit();
                }
                catch
                {
                     thx.Rollback();
                     throw;
                }
            }
        }
    }
