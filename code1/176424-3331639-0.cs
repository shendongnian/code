			runtime = IronPython.Hosting.Python.CreateRuntime();
		}
		public void Run(string script, params object[] variables)
		{
			var scriptSource = runtime.GetEngineByFileExtension("py").CreateScriptSourceFromString(script, SourceCodeKind.Statements);
			var scope = runtime.GetEngineByFileExtension("py").CreateScope();
			foreach (var variable in variables)
				foreach (var property in variable.GetType().GetProperties())
					if (property.CanRead)
						scope.SetVariable(property.Name, property.GetValue(variable, null));
			scriptSource.Execute(scope);
