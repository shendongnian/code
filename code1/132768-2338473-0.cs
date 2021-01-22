    		private string GetExeDir()
		{
			System.Reflection.Assembly ass = System.Reflection.Assembly.GetExecutingAssembly();
			string codeBase = System.IO.Path.GetDirectoryName(ass.CodeBase);
			System.Uri uri = new Uri(codeBase);
			return uri.LocalPath;
		}
