    IReadOnlyList<Customer> customerList = new Customer[]
    {
        new Customer { Name = "test1", Id = 999 },
        new Customer { Name = "test2", Id = 915 },
        new Customer { Name = "test8", Id = 986 },
        new Customer { Name = "test9", Id = 988 },
        new Customer { Name = "test4", Id = 997 },
        new Customer { Name = "test5", Id = 920 },
    };
    int currentIndex = 3;   //want to get object Name = "test8", Id = 986
    var result = customerList[currentIndex];
    customerList.Add(new Customer()); // doesn't compile
    customerList[currentIndex] = new Customer(); // doesn't compile
