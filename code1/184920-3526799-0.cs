    var list1 = new int[] { 1, 2, 3 };
    var list2 = new int[] { 1 };
 
    var output = list1.Except(list2).First();
    Console.WriteLine(output);  // prints "2"
