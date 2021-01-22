        public static void EndContextSession()
        {
            var session = CurrentSessionContext.Unbind(Factory);
            if (session != null && session.IsOpen)
            {
                try
                {
                    if (session.Transaction != null && session.Transaction.IsActive)
                    {
                        // an unhandled exception has occurred and no db commit should be made
                        session.Transaction.Rollback();
                    }
                }
                finally
                {
                    session.Close();
                    session.Dispose();
                }
            }
        }
