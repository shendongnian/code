       HashSet<int> uniqueList = new HashSet<int>();
       uniqueList.Add(1); // List has values 1
       uniqueList.Add(2);  // List has values 1,2
       uniqueList.Add(1);  // List has values 1,2
       Console.WriteLine(uniqueList.Count); // it will return 2
