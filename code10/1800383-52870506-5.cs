    for (int i = 0; i < 2; i++)
       Console.WriteLine("Creating " + new A());
    
    for (int i = 0; i < 4; i++)
       Console.WriteLine("Creating " + new B());
    
    for (int i = 0; i < 1; i++)
       Console.WriteLine("Creating " + new C());
     
    foreach (var item in BaseClass.Counter.Keys)
       Console.WriteLine(item + " " + BaseClass.Counter[item] );
    
