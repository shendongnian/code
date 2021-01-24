    // check if the list at dictionary[0] has at least one instance of userInput in it's collection,
    // otherwise return null
    var toCheck = dictionary[0].FirstOrDefault(x => x == userInput);
 
    // if it's not null, the answer was found in the list of possible answers for that question    
    if (toCheck != null)
    {
        // ...
    }
    
