    object[] a1 = { "string", 123, true };
    object[] a2 = { "string", 123, true };
            
    Console.WriteLine (a1 == a2);        // False (because arrays is reference types)
    Console.WriteLine (a1.Equals (a2));  // False (because arrays is reference types)
            
    IStructuralEquatable se1 = a1;
    //Next returns True
    Console.WriteLine (se1.Equals (a2, StructuralComparisons.StructuralEqualityComparer)); 
