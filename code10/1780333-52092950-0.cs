	List<int> list = new List<int>(){ 255, 0, 0, 255, 0, 255, 255, 0, 255 };
	List<int> secondList= new List<int>(){ 128, 1,  2, 64,  0,  4, 32,  16, 8 };
	
	var matches = list.Zip(secondList, Tuple.Create)
					  .Where(t => t.Item1 == 255)
					  .Select(t => t.Item2);
					  
	Console.WriteLine(matches.Count());
	Console.WriteLine(matches.Sum());
