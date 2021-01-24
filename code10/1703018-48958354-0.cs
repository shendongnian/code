	static class ExtensionMethods
	{
		static public string GetStuffInsideParentheses(this string input)
		{
			int i = input.IndexOf("(");
			int j = input.LastIndexOf(")");
			if (i == -1 || j == -1 || j < i) return null;
			return input.Substring(i+1, j-i-1);
		}
	}
	public class Program
	{
		public static void Main()
		{
			var input = "(blue,(hmmm) derp)";
			var output = input.GetStuffInsideParentheses();
			Console.WriteLine(output);
		}
	}
