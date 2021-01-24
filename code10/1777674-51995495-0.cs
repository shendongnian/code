	void Main()
	{
		var file = Path.Combine(
			Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
			"TestFile.txt");
	
		var array = GetValues<String>(file).ToArray();
		
		foreach (var item in array)
		{
			Console.WriteLine(item);
		}
	}
	
	private IEnumerable<T> GetValues<T>(String file)
	{
		using (StreamReader stream = new StreamReader(file))
		{
			while (true)
			{
				var next = stream.ReadLine();
				if (next == null)
				{
					break;
				}
				yield return (T)Convert.ChangeType(next, typeof(T));
			}
		}
	}
