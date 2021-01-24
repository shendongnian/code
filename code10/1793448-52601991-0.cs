    public class LoggingCommandInterceptor : DbCommandInterceptor
    {
        public override void ReaderExecuting(DbCommand command,
            DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            var parameters = command.Parameters.Cast<DbParameter>()
                .Select(x => $"{x.ParameterName}:{x.Value}");
            // It's up to you how you initialize the logger
            GetLogger().Debug($"Parameters: {string.Join(", ", parameters)}\r\n Query: {command.CommandText}");
            base.ReaderExecuting(command, interceptionContext);
        }
    }
