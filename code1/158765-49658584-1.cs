		public static void TestExtensions()
		{
			string[] searchTerms = { "FOO", "BAR" };
			string[] documents = {
				"Hello foo bar",
				"Hello foo",
				"Hello"
			};
			foreach (var document in documents)
			{
				Console.WriteLine("Testing: {0}", document);
				Console.WriteLine("ContainsAny: {0}", document.ContainsAny(searchTerms, StringComparison.OrdinalIgnoreCase));
				Console.WriteLine("ContainsAll: {0}", document.ContainsAll(searchTerms, StringComparison.OrdinalIgnoreCase));
				Console.WriteLine();
			}
		}
