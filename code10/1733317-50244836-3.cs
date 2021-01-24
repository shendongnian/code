    var twoDict = new TwoKeyDictionary<int, string, float>();
    twoDict.Add(0, "a", 0.5f);
    twoDict.Add(2, "b", 0.25f);
    Console.WriteLine(twoDict[0]);     // Prints "0.5"
    Console.WriteLine(twoDict[2]);     // Prints "0.25"
    Console.WriteLine(twoDict["a"]);   // Prints "0.5"
    Console.WriteLine(twoDict["b"]);   // Prints "0.25"
    
    twoDict.Add(0, "d", 2);            // Throws exception: 0 has already been added, even though "d" hasn't
    twoDict.Add(1, "a", 5);            // Throws exception: "a" has already been added, even though "1" hasn't
