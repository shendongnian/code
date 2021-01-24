	void Main()
	{
		//populate
		var data = Enumerable.Range(1,16).Select(x => 
			Enumerable.Range(1,26).Select(y => 
				Convert.ToChar(64 + y)
			)
		);
		//output one way
		Console.WriteLine("\r\nMethod 1\r\n");    
		foreach(var row in data)
		{
			foreach(var cell in row)
			{
				Console.Write(cell);
			}
			Console.WriteLine();
		}
		//or another
		Console.WriteLine("\r\nMethod 2\r\n");    
		data.ToList().ForEach(row => {
			row.ToList().ForEach(cell => 
				Console.Write(cell)
			); 
			Console.WriteLine();
		});
		//or another approach convert each row from a collection of chars to strings separated by spaces, then join all the strings(rows) to one string separated by line breaks
		Console.WriteLine("\r\nMethod 3\r\n");    
		var output = string.Join("\r\n", data.Select(row => 
			string.Join(" ", row.Select(cell => 
				cell.ToString()
			))
		)); 
		Console.WriteLine(output);
	}
