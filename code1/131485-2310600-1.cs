            var List = new List<MyClass> { 
                new MyClass { Property1 = 1, Property2 = 2, Property3 = 3},
                new MyClass { Property1 = 10, Property2 = 20, Property3 = 30},
                new MyClass { Property1 = 1, Property2 = 2, Property3 = 3} };
            // method 1 - anonymous class
            var thisList = (from MyClass thisClass in List
                            select new
                            {
                                thisClass.Property1,
                                thisClass.Property2,
                                thisClass.Property3
                            }).Distinct().ToList();
            // method 2 - anonymous class
            var result = List.Select(x => new { x.Property1, x.Property2, x.Property3 }).Distinct().ToList();
            // method 3 - group (get the first MyClass object from the 'distinct' group)
            var grouped = (from item in List
                          group item by new { item.Property1, item.Property2, item.Property3 } into itemGroup
                          select itemGroup.First()).ToList();
