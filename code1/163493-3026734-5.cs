	var instance1 = Doubleton.Instance;
	var instance2 = Doubleton.Instance;
	
	var instance1Again = Doubleton.Instance;
	var instance2Again = Doubleton.Instance;
	
	Console.WriteLine("The following 2 lines should be true:");
	Console.WriteLine(instance1.Equals(instance1Again));
	Console.WriteLine(instance2.Equals(instance2Again));
	
	Console.WriteLine("---");
	Console.WriteLine("The next 50 lines should alternate instances:");
	for (int i = 0; i < 50; i++)
	{
		var instance = Doubleton.Instance;
		Console.WriteLine("I have instance # " + instance.GetInstanceIndex());
	}
