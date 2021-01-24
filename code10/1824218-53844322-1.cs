	public static IEnumerable<LogEntry> OpenLog(string filename)
	{
		using (var reader = new StreamReader(filename))
		{
    		string line = null;
			while ((line = reader.ReadLine()) != null)
			{
				string[] parts = line.Split(' ');
				if (parts.Length != 6)
					continue;
				float f1, f2, f3, f4;
				if (!float.TryParse(parts[2], out f1) || !float.TryParse(parts[3], out f2) || !float.TryParse(parts[4], out f3) || !float.TryParse(parts[5], out f4)
					continue;
				yield return new LogEntry
				{
					GroupIndex = parts[0],
					GroupKey = parts[1],
					Value1 = f1,
					Value2 = f2,
					Value3 = f3,
					Value4 = f4,
				}
			}
		}
	}
