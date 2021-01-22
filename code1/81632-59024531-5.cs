    List<int> list = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9};
	int shift = 4;  //enter the number of elements to be shifted
		
	//printing the list before rotating
	Console.Write("Before\t: ");
	for(int i = 0; i< list.Count; i++)
	{
	    Console.Write(list[i] + " ");	
	}
		
	list = Rotate<int>(list, shift, -1);
		
	//printing the list after rotating
	Console.Write("\nAfter \t: ");
	for(int i = 0; i< list.Count; i++)
	{
		Console.Write(list[i] + " ");	
	}
