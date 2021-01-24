    Dictionary<int, int> dict;               // dict is not assigned to anything and is null
    var tempDictionary = new Dictionary<int, int>();
    tempDictionary.Add(1, 2);
    tempDictionary.Add(3, dict[1]);          // CS0165	Use of unassigned local variable 'dict'
    dict = tempDictionary;                   // now dict is assigned and can be used
