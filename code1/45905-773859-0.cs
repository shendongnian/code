    var collectionNames = new Dictionary<Int32,String>();
    Array.ForEach(Enum.GetNames(typeof(YOUR_TYPE)), name => 
    { 
      Int32 val = (Int32)Enum.Parse(typeof(YOUR_TYPE), name, true); 
      collectionNames[val] = name; 
    }); 
