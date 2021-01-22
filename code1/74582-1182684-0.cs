    string[] strNums = {"111","32","33","545","1","" ,"23",null};
        var nums = strNums.Where( s => 
			{
			int result;
			return !string.IsNullOrEmpty(s) && int.TryParse(s,out result);
			}
		)
		.Select(s => int.Parse(s))
		.OrderBy(n => n);
		
		foreach(int num in nums)
		{
		    Console.WriteLine(num);
		}
