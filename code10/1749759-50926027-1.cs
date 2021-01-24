    // to future maintainers     the reason we introduced this interceptor is that we couldnt find a way to persuade ef6 to map numeric(1,0) columns in sqlserver into bool columns
    // to future maintainers     we want this sort of select statement
    // to future maintainers     
    // to future maintainers        SELECT 
    // to future maintainers           ...
    // to future maintainers           [Extent2].[FB_YN]  AS [FB_YN], 
    // to future maintainers           ...
    // to future maintainers        FROM  ...
    // to future maintainers     
    // to future maintainers     to be converted into this sort of select statement
    // to future maintainers     
    // to future maintainers        SELECT 
    // to future maintainers           ...
    // to future maintainers           CAST ([Extent2].[FB_YN]  AS BIT) AS [FB_YN],    -- the BIT cast ensures that the column will be mapped without trouble into bool properties
    // to future maintainers           ...
    // to future maintainers        FROM  ...
    // to future maintainers
	// to future maintainers     note0   the regex used assumes that all boolean columns end with the _yn postfix   if your boolean columns follow a different naming scheme you
	// to future maintainers     note0   have to tweak the regular expression accordingly
	// to future maintainers
    // to future maintainers     note1   notice that special care has been taken to ensure that we only tweak the columns that preceed the FROM part  we dont want to affect anything
    // to future maintainers     note1   after the FROM part if the projects involved ever get upgraded to employ efcore then you can do away with this approach by simply following
	// to future maintainers     note1   the following small guide
    // to future maintainers
    // to future maintainers                                           https://docs.microsoft.com/en-us/ef/core/modeling/relational/data-types
    // to future maintainers
    public sealed class MsSqlServerHotFixerCommandInterceptor : IDbCommandInterceptor
    {
        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            HotfixFaultySqlCommands(command, interceptionContext);
        }
        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            HotfixFaultySqlCommands(command, interceptionContext);
        }
        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            HotfixFaultySqlCommands(command, interceptionContext);
        }
        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
        }
        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
        }
        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
        }
        static private void HotfixFaultySqlCommands<TResult>(IDbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            if ((interceptionContext.DbContexts.FirstOrDefault() as IVNextDbContext)?.DatabaseType != DatabaseTypeEnum.MicrosoftSqlServer)
                return;
            if (!command.CommandText.TrimStart().StartsWith("SELECT", ignoreCase: true, culture: CultureInfo.InvariantCulture))
                return;
            command.CommandText = BooleanColumnSpotter.Replace(command.CommandText, "CAST ($1 AS BIT)");
        }
        static private readonly Regex BooleanColumnSpotter = new Regex(@"((?<!\s+FROM\s+.*)([[][a-zA-Z0-9_]+?[]][.])?[[][a-zA-Z0-9_]+[]])(?=\s+AS\s+[[][a-zA-Z0-9_]+?_YN[]])", RegexOptions.IgnoreCase);
    }
