    protected virtual TResult ExecuteAndLogError<TResult>(Func<TResult> code, string sql, SqlParameterCollection parameters = null)
    {
	    try {
		    if ((System.Diagnostics.Debugger.IsAttached))
			    PrintSqlToDebug(sql, parameters);
		    return code();
	    } catch (Exception ex) {
		    LogError(sql, parameters, ex);
		    throw;
	    }
    } 
