    var server = new Server(@".\SQLExpress");
	var database = server.Databases["mydb"];
	var scripter = new Scripter(server);
	//scripter.Options.WithDependencies = true; //didn't even need this option
	scripter.Options.ScriptData = true;
	scripter.Options.ScriptSchema = false;
    var tables = database.Tables.Cast<Table>().Where(t => !t.IsSystemObject).ToList();
	var scripts = scripter.EnumScriptWithList(tables.Select(t => t.Urn).ToArray());
	return string.Join("\n", scripts.Select(s => s));
