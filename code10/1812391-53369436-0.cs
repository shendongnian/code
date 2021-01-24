    var e1 = new Employee { Name = "abc" };
    Employee e2 = e1;
    var e3 = new Employee { Name = "abc" };
    var e4 = new Employee { Name = "123" };
    
    Console.WriteLine(e1 == e4); // false
    Console.WriteLine(e1 == e3); // false, since they don't point to the same object, they just contain the same values
    Console.WriteLine(e1 == e2); // true, since they point to the same object
