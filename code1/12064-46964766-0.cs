		public static void Main()
		{
			List<string> salesLines = new List<string>();
			Console.InputEncoding = Encoding.UTF8;
			using (StreamReader reader = new StreamReader(Console.OpenStandardInput(), Console.InputEncoding))
			{
				string stdin;
				do
				{
					StringBuilder stdinBuilder = new StringBuilder();
					stdin = reader.ReadLine();
					stdinBuilder.Append(stdin);
					var lineIn = stdin;
					if (stdinBuilder.ToString().Trim() != "")
					{
						salesLines.Add(stdinBuilder.ToString().Trim());
					}
				} while (stdin != null);
			}
