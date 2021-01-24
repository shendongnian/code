    static async internal Task<int> executeSql(string tsql, string connectionString, int commandTimeout, System.Diagnostics.Stopwatch watch) {
    	int i = -1;
    	Exception ex = null;
    	try {
    		using (var con = new SqlConnection(connectionString)) {
    			con.Open();
    			using (var cmd = new SqlCommand("set xact_abort on;" + tsql, con)) {
    				cmd.CommandType = System.Data.CommandType.Text;
    				cmd.CommandTimeout = commandTimeout;
    				watch.Start();
    				i = await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
    			}
    		}
    	} catch (Exception e) {
    		ex = e;
    	} finally {
    		watch.Stop();
    		if (ex != null) { throw ex; }
    	}
    	return i;
    }
    // ....
    var tasks = new Task<int>[commands.Length];
    var watches = new System.Diagnostics.Stopwatch[commands.Length];
    
    try {
    	for (int i = 0; i < commands.Length; i++) {
    		watches[i] = new System.Diagnostics.Stopwatch();
    		tasks[i] = executeSql(commands[i], connectionString, (int)commandTimeout, watches[i]);
    	}
    	Task.WaitAll(tasks);
	} catch (AggregateException) { 
		// ...
