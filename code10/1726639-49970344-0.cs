	var a = new A();
	Console.WriteLine(a.GetType().Name); // Output: A
	Console.WriteLine(a.GetType().BaseType?.Name); // Output: MyBase
	
	var b = new B();
	Console.WriteLine(b.GetType().Name); // Output: B
	Console.WriteLine(b.GetType().BaseType?.Name); // Output: A
    // A simple loop to get to visit the derivance chain
	var currentType = b.GetType();
	while (currentType != typeof(object))
    {
		Console.WriteLine(currentType.Name);
		currentType = currentType.BaseType;
    }
    // Output: B A MyBase
