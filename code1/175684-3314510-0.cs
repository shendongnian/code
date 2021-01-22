		public string Evaluate( string scriptResultVariable, string scriptBlock )
		{
			object result;
			try
			{
				ScriptSource source = 
					_engine.CreateScriptSourceFromString( scriptBlock, SourceCodeKind.Statements );
				result = source.Execute( _scope );
			}
			catch ( Exception ex )
			{
				result = "Error executing code: " + ex;
			}
			return result == null ? "<null>" : result.ToString();
		}
