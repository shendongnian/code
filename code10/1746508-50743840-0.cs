    List<int> list1 = new List<int>();
      list1.Add(1);
      list1.Add(2);
      list1.Add(3);
    
    List<int> list2 = new List<int>();
                
      list2.Add(2);
      list2.Add(3);
               
    
     Console.WriteLine( list1.Intersect(list2).SequenceEqual(list2)); // Will return true
