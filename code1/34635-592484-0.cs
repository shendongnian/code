    // Old way
    foreach (SmartEnumerable<string>.Entry entry in
                     new SmartEnumerable<string>(list))
    
    // Better way
    foreach (SmartEnumerable<string>.Entry entry in
                    SmartEnumerable.Create(list))
    
    // Best way (C# 3.0)
    foreach (var entry in list.AsSmartEnumerable())
