    override public object ExecuteScalar()
    {
        SqlConnection.ExecutePermission.Demand();
        // Reset _pendingCancel upon entry into any Execute - used to synchronize state
        // between entry into Execute* API and the thread obtaining the stateObject. 
        _pendingCancel = false;
        SqlStatistics statistics = null;
        IntPtr hscp;
        Bid.ScopeEnter(out hscp, "<sc.sqlcommand.executescalar|api> %d#", ObjectID);
        try
        {
            statistics = SqlStatistics.StartTimer(Statistics);
            SqlDataReader ds = RunExecuteReader(0, RunBehavior.ReturnImmediately, true, ADP.ExecuteScalar);
             
            object retResult = null;
            try
            {
                if (ds.Read())
                {
                    if (ds.FieldCount > 0)
                    {
                        retResult = ds.GetValue(0);
                    }
                }
                return retResult;
            }
            finally
            {
                // clean off the wire 
                ds.Close();
            }
        }
        finally
        {
            SqlStatistics.StopTimer(statistics);
            Bid.ScopeLeave(ref hscp);
        }
    }
