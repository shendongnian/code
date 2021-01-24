		StringBuilder sb = new StringBuilder();
		sb.Append("5,5");
		sb.Append(",");
		sb.Append("7,9");
		sb.Append(",");
		sb.Append("4,7,6,1");
		sb.Append(",");
		sb.Append("1");	
		
		string[] arr = sb.ToString().Split(',');
		int[] test = Array.ConvertAll(arr, s => int.Parse(s));
		
		
		var count = test
			.GroupBy(e => e)
			.Where(e => e.Count() == 1)
			.Select(e => e.First()).ToList();
    output: 
    
    9
    4
    6
