    var query = source.Where(item => item.Value1.HasValue).Where(item => (int)(item.Value1.Value) == 1); //item is DataModel
    var query1 = source.Where(item => item.Value1.HasValue).Where(item => item.Value1.Value ==  (int)TypeInEnum.A); //item is IData
    
    var eq = query.SequenceEqual(query1);   
    Console.WriteLine(String.Format("results: {0}",eq? "Equal": "Not equal")); 
