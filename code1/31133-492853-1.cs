    Test t = new Test();
    t.Number = 5;
    Console.WriteLine(t.NumberAsString); // should print out "5"
    t.NumberAsString = "5";
    Console.WriteLine(t.Number); // should print out "5"
