        List<Foo> foos = new List<Foo>();
        foos.Add(new Foo() { id = 1, name = "test" });
        foos.Add(new Foo() { id = 1, name = "test1" });
        foos.Add(new Foo() { id = 2, name = "test2" });
        //Example 1
        //get all Foos's by Id == 1
        var list1 = foos.AddFilter(FilterById, 1);
        
        //Example 2
        //get all Foo's by name ==  "test1"
        var list2 = foos.AddFilter(FilterByName, "test1");
       
        //Example 3
       //get all Foo's by Id and Name
       var list1 = foos.AddFilter(FilterById, 1).AddFilter(FilterByName, "test1");
