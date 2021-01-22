    var thisList = new List<string>{ "a", "b", "c" };
    var otherList = new List<string> {"a", "b"};
        
    var theOnesThatDontMatch = thisList
            .Where(item=> otherList.All(otherItem=> item != otherItem))
            .ToList();
        
    var theOnesThatDoMatch = thisList
            .Where(item=> otherList.Any(otherItem=> item == otherItem))
            .ToList();
    		
    Console.WriteLine("don't match: {0}", string.Join(",", theOnesThatDontMatch));
    Console.WriteLine("do match: {0}", string.Join(",", theOnesThatDoMatch));
    	
    //Output:
    //don't match: c
    //do match: a,b
