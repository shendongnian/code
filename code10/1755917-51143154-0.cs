    List<MyClass> myObjects = new List<MyClass>();
    myObjects.Add(new MyClass());
    myObjects.Add(new MyClass());
    myObjects.Add(new MyClass());
    
    int[] numbers = new int[] { 1, 2, 3 };
    int i = 0;
    myObjects.ForEach(x =>
    {
    	x.Number = numbers[i];
    	i++;
    });
