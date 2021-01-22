    BijectiveDictionary<int, bool> a = new BijectiveDictionary<int, bool>();
    
    a.Add(5, true);
    a.Add(6, false);
    
    Console.WriteLine(a[5]);// => True
    Console.WriteLine(((BijectiveDictionary < bool, int>)a)[true]);// => 5
    //or
    Console.WriteLine(a.Reversed[true]);// => 5
