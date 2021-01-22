    int[] secondmarks = {20, 15, 31, 34, 35, 50, 40, 90, 99, 100, 20};
    
    IEnumerable<int> finallist = secondmarks.OrderByDescending(c => c);
    
    int[,] orderedMarks = new int[2, finallist.Count()];
    
    Enumerable.Range(0, finallist.Count()).ToList().ForEach(k => {orderedMarks[0, k] = (int) finallist.Skip(k).Take(1).Average();
    orderedMarks[1, k] = k + 1;}); 
    
    Enumerable.Range(0, finallist.Count()).Select(m => new {Score = orderedMarks[0, m], Place = orderedMarks[1, m]}).Dump();
