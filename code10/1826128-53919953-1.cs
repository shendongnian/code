    var a1 = new int[5] {1,2,3,4,5}; 
	var a2 = new int[7] {1,2,3,4,5,6,7};
	
	var maxLength = a1.Length > a2.Length ? a1.Length : a2.Length;
	
	var outputArray = new int[maxLength];
	
	for(var i = 0; i < maxLength; i++)
	{
		if(a1.Length < i + 1)
		{
			outputArray[i] = a2[i];
			continue;
		}
		
		if(a2.Length < i + 1)
		{
			outputArray[i] = a1[i];
			continue;
		}
		
		outputArray[i] = a1[i] + a2[i];
	}
	
	Console.Write(outputArray.GetValue(6));
