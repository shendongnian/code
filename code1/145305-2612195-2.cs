    int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    
    int target = 7;
    int currentIndex = 0;
    
    var query = (from item in numbers
                 select new
                 {
                     Value = item,
                     Index = currentIndex++
                 })
                 .ToList();
    
    var query2 = from item1 in query
                 from item2 in query
                 where item1.Value + item2.Value == target 
                 && item1.Index < item2.Index
                 select new
                 {
                     Item1 = item1,
                     Item2 = item2
                 };
    
    foreach (var itemPair in query2)
    {
        Console.WriteLine("{0}:{1}\t{2}:{3}", 
            itemPair.Item1.Index, 
            itemPair.Item1.Value, 
            itemPair.Item2.Index, 
            itemPair.Item2.Value);
    }
