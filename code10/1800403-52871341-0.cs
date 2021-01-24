            string s = "your,comma,string";
			string[] ss = s.Split(',');
			Print500(ss, 0);
		private void Print500(IEnumerable<string> ies, int skip)
		{
			if (skip > ies.Count())
				return;
			Console.Out.WriteLine(string.Join(",", ies.Skip(skip).Take(500)));
			Print500(ies, skip + 500);
		}
