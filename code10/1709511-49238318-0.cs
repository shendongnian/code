    var report   = string.Empty;
	var fileName = Server.MapPath(Constants.BACKUP_FILE_NAME);
	var server      = new Server(new ServerConnection(new SqlConnection(Constants.BACKUP_CONNECTION_STRING)));
	var options     = new ScriptingOptions();
	var databases   = server.Databases[Constants.BACKUP_DATABASE_NAME];                    
	options.FileName                = fileName;
	options.EnforceScriptingOptions = true;
	options.WithDependencies        = true;
	options.IncludeHeaders          = true;
	options.ScriptDrops             = false;
	options.AppendToFile            = true;
	options.ScriptSchema            = true;
	options.ScriptData              = true;
	options.Indexes                 = true;
	report = "<h4>Table Scripts</h4>";
	foreach (var table in Constants.BACKUP_TABLES)
	{
		databases.Tables[table, Constants.BACKUP_SCHEMA_NAME].EnumScript(options);                        
		report += "Script Generated: " + table + "<br>";
	}
