    Type[] typeArguments = t.GetGenericArguments();
    Console.WriteLine("\tList type arguments ({0}):", typeArguments.Length);
    foreach (Type tParam in typeArguments)
    {
        Console.WriteLine("\t\t{0}", tParam);
    }
