    public int Data {get; set;};
    
    Console.WriteLine("Enter input:");
    string line = Console.ReadLine();
    
    var operatorObject = new Operator();
    var result = operatorObject.GetAdd(a);
    
    Console.WriteLine(result);
    Console.ReadLine();
