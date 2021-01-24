    Queue<int> integers = new Queue<int>();
    
    for (int i = 0; i < 20; i++)
    {
    	integers.Enqueue(i);
    }
    
    Console.WriteLine(integers.Count); // 20
    Console.WriteLine();
    
    while(integers.Count > 0)
    {
    	Console.WriteLine(integers.Count + ": " + integers.Dequeue());
    }
    
    Console.WriteLine();
    Console.WriteLine(integers.Count); // 0
