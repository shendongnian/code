	public class Program
	{
		static void Main(string[] args)
		{
			IDictionary<int, string> words = new Dictionary<int, string>();
	        words.Add(0, "bob");
			words.Add(1, "alice");
			words.Add(2, "john");
			foreach (KeyValuePair<int, string> word in words.OrderBy(w => w.Key))
			{
				Console.WriteLine(word.Value);
			}
			Console.ReadLine();
		}
	}
