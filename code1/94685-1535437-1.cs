    dynamic v1, v2, v3;
    v1 = new Vector4(1, 2, 3, 4);
    v2 = v1.rgb;
    // Need a length check in TryGetMember to get v2.r to work nicely here. 
    // In lieu of that...
    Console.WriteLine("v2.r: {0}", v2[0]);
    // Prints: v2 has 3 elements.
    Console.WriteLine("v2 has {0} elements.", v2.Length);
    v3 = new Vector4(5, 6, 7, 8);
    v3.ar = v2.gb; // yes, the names are preserved! v3 = (3, 4, 7, 8)
    
    v2.r = 5; // fails: need a length check in TrySetMember to get this working
    v2.a = 5; // fails: v2 has no 'a' element, only 'r', 'g', and 'b'
