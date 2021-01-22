    var src = new [] {1, 2, 3, 4, 5, 6}; 
    var c3 = src.Chunks(3);      // {{1, 2, 3}, {4, 5, 6}}; 
    var c4 = src.Chunks(4);      // {{1, 2, 3, 4}, {5, 6}}; 
    
    var sum   = c3.Select(c => c.Sum());    // {6, 15}
    var count = c3.Count();                 // 2
    var take2 = c3.Select(c => c.Take(2));  // {{1, 2}, {4, 5}}
