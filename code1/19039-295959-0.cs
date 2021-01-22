	static class StringHelpers
	{
		public static string Repeat(this string Template, int Count)
		{
			string Combined = Template;
			while (Count > 1) {
				Combined += Template;
				Count--;
			}
			return Combined;
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			string s = "abc";
			Console.WriteLine(s.Repeat(3));
			Console.ReadKey();
		}
