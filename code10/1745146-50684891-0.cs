    var instantiationListArgs = typeof(MyList<>).GetMethod("Add").DeclaringType.GetGenericArguments();
    var myListArg = typeof(MyList<>).GetGenericArguments();
    var listArgs = typeof(List<>).GetGenericArguments();
    Console.WriteLine(myListArg[0] == instantiationListArgs[0]); // Will output true, List was instantiated for the T in MyList
    Console.WriteLine(listArgs[0] == instantiationListArgs[0]); // Will be false. The generic argument is different then the T in the free List<>
