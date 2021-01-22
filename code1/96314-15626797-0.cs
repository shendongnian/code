	class Program
	{
		static void Main(string[] args)
		{
			var dictionary = new Dictionary<string, int>()
            {
                {"1", 1}, {"2", 2}, {"3", 3}
            };
			string[] keyArray = new string[dictionary.Keys.Count];
			dictionary.Keys.CopyTo(keyArray, 0);
			foreach (var s in keyArray)
			{
				dictionary[s] = 1;
			}
		}
	}
