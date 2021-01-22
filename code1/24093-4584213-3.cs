    var listOfInts = new List<int>();
    var listOfStrings = new List<string>();
    
    bool areSameGenericType =
        listOfInts.GetType().GetGenericTypeDefinition() ==
        listOfStrings.GetType().GetGenericTypeDefinition();
    // areSameGenericType == true
