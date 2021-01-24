    var dict = new Dictionary<int, List<int>>();
	
	Console.WriteLine("Enter number of Arrays do you want : ");
	
    int numberOfArrays = int.Parse(Console.ReadLine());
	
	for(int k = 1; k < numberOfArrays; k++)
	{
		var currentArray = dict[k] = new List<int>();
	
		Console.WriteLine($"Enter array {k} Length:");
		
		int arrayLength = int.Parse(Console.ReadLine());
        
		for (int j = 0; j < arrayLength; j++)
        {
           Console.WriteLine($"Enter the {j}-th Element you want in Array {k}: ");
           currentArray.Add(int.Parse(Console.ReadLine()));
        }
		
	}
	
	foreach(var pair in dict)
	{
		 Console.WriteLine($"{pair.Key}-th array elements : ");
		 
		 foreach(var element in pair.Value)
		 {
		 	Console.WriteLine(element);
		 }
	}
