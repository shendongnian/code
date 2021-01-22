    DateTime dt1 = DateTime.Now;
    Console.Write("Test 1: ");
    Console.WriteLine($"{dt1:yyyy-MM-dd hh:mm:ss}"); //works
    
    DateTime? dt2 = DateTime.Now;
    Console.Write("Test 2: ");
    Console.WriteLine($"{dt2:yyyy-MM-dd hh:mm:ss}"); //Works
    
    DateTime? dt3 = null;
    Console.Write("Test 3: ");
    Console.WriteLine($"{dt3:yyyy-MM-dd hh:mm:ss}"); //Works - Returns empty string
    Output
    Test 1: 2017-08-03 12:38:57
    Test 2: 2017-08-03 12:38:57
    Test 3: 
