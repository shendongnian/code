	public static class StringBuilderExtensions
	{
		public class StringBuilderWrapper : StringBuilder
		{
			private readonly string _prefix;
			
			public StringBuilderWrapper(string prefix)
			{
				_prefix = prefix;
			}
			
			public StringBuilderWrapper AppendLine(string line)
			{
				base.Append(prefix)
				base.AppendLine(line);
                return this;
			}
		}
		
		public static StringBuilderWrapper SetNewLineInitialCharacter(string prefix)
		{
			return new StringBuilderWrapper(prefix);
		}
	}
