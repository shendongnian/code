	public class Program
	{
		static void Main(string[] args)
		{
			IDictionary<int, string> words = new Dictionary<int, string>();
			words.Add(new KeyValuePair<int, string>(0, "bob"));
			words.Add(new KeyValuePair<int, string>(1, "alice"));
			words.Add(new KeyValuePair<int, string>(2, "john"));
			foreach (KeyValuePair<int, string> word in words.OrderBy(w => w.Key))
			{
				Console.WriteLine(word.Value);
			}
			Console.ReadLine();
		}
	}
