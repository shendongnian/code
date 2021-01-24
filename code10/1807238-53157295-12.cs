	void Main()
	{
	
	    //populate
	    var data = Enumerable.Range(1,16).Select(x => 
	        Enumerable.Range(1,26).Select(y => 
	            Convert.ToChar(64 + y)
	        )
	    );
	    //display
		Console.WriteLine(data.ToTableFormatString());
	}
	
	public static class TableCreationExtension
	{
		
		//converts the output of ToTableFormat to a single string
		public static string ToTableFormatString(this IEnumerable<IEnumerable<char>> rows) =>
			string.Join("\r\n", rows.ToTableFormat());
	
		/* 
			calls other methods to convert the data to the inner table format, then surrounds with a double edged box
			╔═════╗
			║inner║
			║table║
			║goes ║ 
			║here ║
			╚═════╝
			info on required characters here: https://en.wikipedia.org/wiki/Box-drawing_character			
		*/
		public static IEnumerable<string> ToTableFormat(this IEnumerable<IEnumerable<char>> rows)
		{
			var rowsAsStrings = rows.ToInnerTableFormat();
			var rowLength = rowsAsStrings.First().Length; //assume that all rows are the same length, so the length of the first equals the length of all others
			//first row of box
			yield return string.Format("╔{0}╗", new string('═', rowLength));
			//each row within the box
			foreach(var row in rowsAsStrings)
			{
				yield return string.Format("║{0}║", row);
			}
			//last row of box
			yield return string.Format("╚{0}╝", new string('═', rowLength));
		}
		
		/*
			calls other methods to convert each row into a formatted string
			Adds a separator between each row.
			
			each
			---------
			row
			---------
			separated
		*/
		public static IEnumerable<string> ToInnerTableFormat(this IEnumerable<IEnumerable<char>> rows)
		{
			bool returnInnerLine = false;
			int rowLength = 0; //assume all rows are the same length
			foreach(var row in rows)
			{
				var formattedRow = row.ToFormattedRow();
				if (returnInnerLine)
				{
					yield return new string('-', rowLength); //returns a line of -s the same length as a row for a between-row separator
				}
				else
				{
					returnInnerLine = true;
					rowLength = formattedRow.Length;
				}
				yield return formattedRow;
			}
		}
		
		//converts `'A', 'B', 'C'` to "A|B|C" 
		public static string ToFormattedRow(this IEnumerable<char> cellsInRow) =>
			string.Join("|", cellsInRow.Select(c => c.ToString()));
	}
