	public static class StringBuilderExtensions
	{
		public static void AppendUnixLine(this StringBuilder builder, string s)
		{
			builder.Append(s);
			builder.Append('\n');
		}
	}
