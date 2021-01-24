    List<Order> orders = ...;
    var enumerator = orders.GetIndexedListEnumerator();
    enumerator.Index = 10;
    Console.WriteLine(enumerator.Current); // Prints orders[10]
    enumerator.MovePrevious();
    Console.WriteLine(enumerator.Current); // Prints orders[9]
    enumerator.MoveNext();
    enumerator.MoveNext();
    Console.WriteLine(enumerator.Current); // Prints orders[11]
