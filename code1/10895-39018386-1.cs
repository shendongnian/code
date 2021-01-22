		
	public static string GetColumnName(int index) // zero-based
	{
		const byte BASE = 'Z' - 'A' + 1;
		string name = String.Empty;
		do
		{
			name = Convert.ToChar('A' + index % BASE) + name;
			index = index / BASE - 1;
		}
		while (index >= 0);
		return name;
	}
