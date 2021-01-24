       int[] test = { 1, 2, 3, 4 };   
    
       var result = Enumerable
         .Range(1, 1 << test.Length)
         .Where(mask => mask != 0)
         .Select(mask => test 
            .Where((v, i) => ((1 << i) & mask) != 0)
            .ToArray());
    
       Console.Write(string.Join(Environment.NewLine, result
         .Select(item => string.Join(", ", item)));  
