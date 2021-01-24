    var result = myLbaList
      .GroupBy(
         a => new {a.aId, a.bId, a.max, a.min}, // Key
         a => new {a.Col1, a.Col2, a.Col3})     // Values
      .Select(chunk => new {
         // From Key
         aId = chunk.Key.aId,
         bId = chunk.Key.bId, 
         max = chunk.Key.max, 
         min = chunk.Key.min,
    
         // From Values
         Col1 = chunk
           .Where(item => item.Col1.HasValue) // not null items
           .Select(item => item.Col1.Value)   // CustomObject1? to CustomObject1
           .ToList(),  
         Col2 = chunk
           .Where(item => item.Col2.HasValue) 
           .Select(item => item.Col2.Value)
           .ToList(), 
         Col3 = chunk
           .Where(item => item.Col3.HasValue) 
           .Select(item => item.Col3.Value)
           .ToList(),
       })
      .ToList();
