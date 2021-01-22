    List<Foo> list = new List<Foo>();
    ...
    
    if (list.IsOrderedBy(f => f.Name))
       Console.WriteLine("The list is sorted by name");
    else
       Console.WriteLine("The list is not sorted by name");
