    int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    
    int target = 7;
    int currentIndex = 0;
    
    var query = (from item in numbers
                 select new
                 {
                     Number = item,
                     Index = currentIndex++
                 })
                 .ToList();
    
    var query2 = from item1 in query
                 from item2 in query
                 where item1.Number + item2.Number == target && item1.Index < item2.Index
                 select new
                 {
                     Value1 = item1.Number,
                     Value1Index = item1.Index,
                     Value2 = item2.Number,
                     Value2Index = item2.Index
                 };
    
    foreach (var itemPair in query2)
    {
        Console.WriteLine("{0}:{1}\t{2}:{3}", itemPair.Value1Index, itemPair.Value1, itemPair.Value2Index, itemPair.Value2);
    }
