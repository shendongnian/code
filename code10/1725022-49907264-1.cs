    var mixed = new List<KeyValuePair<A, A>>()
    { new KeyValuePair<A, A>(new A() { id = 1, tID = 10, cID = 50, Name = "Q5" },
                             new A() { id = 7, tID = 10, cID = 50, Name = "Q1" }),
      new KeyValuePair<A, A>(new A() { id = 0, tID = 20, cID = 30, Name = "Q2" },
                             new A() { id = 8, tID = 20, cID = 30, Name = "Q2" }),
      new KeyValuePair<A, A>(new A() { id = 1, tID = 10, cID = 50, Name = "Q5" },
                             new A() { id = 9, tID = 30, cID = 20, Name = "Q3" })};
    mixed = mixed.OrderBy(a => a.Key.id == 0).ThenBy(a => a.Key.id).ToList();
    Console.WriteLine("finalAnswers IDs:");
    // Print the IDs of the values (finalAnswers).
    foreach (var item in mixed)
        Console.WriteLine(item.Value.id);
    Console.WriteLine("\ndraftAnswers IDs:");
    // Print the IDs of the keys (draftAnswers).
    foreach (var item in mixed)
        Console.WriteLine(item.Key.id);
