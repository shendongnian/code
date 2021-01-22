    int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    
    int target = 7;
    
    var query = from item1 in numbers.Select((number, index) => new { Number = number, Index = index })
                from item2 in numbers.Select((number, index) => new { Number = number, Index = index })
                where item1.Number + item2.Number == target
                && item1.Index < item2.Index
                select new { Item1 = item1, Item2 = item2 };
    
    foreach (var itemPair in query)
    {
        Console.WriteLine("{0}:{1}\t{2}:{3}",
            itemPair.Item1.Index,
            itemPair.Item1.Number,
            itemPair.Item2.Index,
            itemPair.Item2.Number);
    }
