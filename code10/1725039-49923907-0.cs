    public class LogInfoMessageFilter : OrmLiteExecFilter
    {
        ILog SlackLog = LogManager.GetLogger("SlackLogger");
        public override T Exec<T>(IDbConnection dbConn, Func<IDbCommand, T> filter) 
        {
            var holdProvider = OrmLiteConfig.DialectProvider;
            // casting, skipping type checks for brevity
            var sqlConn = (SqlConnection)dbConn.ToDbConnection();
            // add the event
            sqlConn.InfoMessage += _HandleInfoMessage;
            var dbCmd = CreateCommand(sqlConn);
            try
            {
                return filter(dbCmd);
            }
            finally
            {
                DisposeCommand(dbCmd, sqlConn);
                OrmLiteConfig.DialectProvider = holdProvider;
            }
        }
        private void _HandleInfoMessage(object sender, SqlInfoMessageEventArgs args)
        {
            SlackLog.Info($"what does the sproc say? {args.Message}");
        }
    }
 
    // before opening the connection:
    OrmLiteConfig.ExecFilter = new LogInfoMessageFilter();
