    ILogger logger = new LoggerConfiguration()
          .MinimumLevel.Verbose()
          .WriteTo.MSSqlServer(connectionString,
                               tableName,
                               autoCreateSqlTable: autoCreateSqlTable,
                               restrictedToMinimumLevel: LogEventLevel.Verbose,
                               columnOptions: GetSQLSinkColumnOptions(),
                               batchPostingLimit: batchPostingLimit)          
          .CreateLogger();
