                Server serv = new Server(db);
                Database simba = serv.Databases[dbname];
                Scripter scripter = new Scripter(serv);
                scripter.Options.FileName = "InsertIntoScript.sql";
                scripter.Options.EnforceScriptingOptions = true;
                scripter.Options.WithDependencies = false;
                scripter.Options.IncludeHeaders = true;
                scripter.Options.ScriptDrops = false;
                scripter.Options.AppendToFile = true;
                scripter.Options.ScriptSchema = false;
                scripter.Options.ScriptData = true;
                scripter.Options.Indexes = false;
                string script = "";
                foreach (Table tb in simba.Tables)
                {
                    if (tables.Contains(tb.Name))
                    {
                        IEnumerable<string> sc = scripter.EnumScript(new Urn[] { tb.Urn });
                        foreach (var s in sc)
                            script += s;
                    }
                }
