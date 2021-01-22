    [Conditional("DEBUG")]
    public static class MyDbg
	{
		public static void WriteLine(string str) // and some other params
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(str);
			// etc. appending other params as you see fit
		}
	}
