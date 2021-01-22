		public static string GetExecutable(string command)
		{
			string executable = string.Empty;
			string[] tokens = command.Split(' ');
			for (int i = tokens.Length; i >= 0; i--)
			{
				executable = string.Join(" ", tokens, 0, i);
				if (File.Exists(executable))
					break;
			}
			return executable;
		}
 
