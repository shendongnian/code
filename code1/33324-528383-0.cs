    DateTime t1 = new DateTime(100);
    DateTime t2 = new DateTime(20);
    
    if (DateTime.Compare(t1, t2) >  0) Console.WriteLine("t1 > t2"); 
    if (DateTime.Compare(t1, t2) == 0) Console.WriteLine("t1 == t2"); 
    if (DateTime.Compare(t1, t2) <  0) Console.WriteLine("t1 < t2");
