    		static IEnumerable<string> ReadLinesLazily(string file)
		{
			using (var reader = new StreamReader(file))
			{
				string line = null;
				while ((line = reader.ReadLine()) != null)
				{
					yield return line;
				}
			}
		}
		static void Combine()
		{
			const string link = "<a href=\"{0}\">{1}</a>";
			var links = ReadLinesLazily("domains.txt").Zip(ReadLinesLazily("titels.txt"), (d, t) => String.Format(link, d, t))
			// write links here
		}
