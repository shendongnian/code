    IQueryable<MyObject> objects = new[]
    {
        new MyObject{ GroupId = 3, Index = 31, OtherProperty = "Group 3 / Index 31" },
        new MyObject{ GroupId = 3, Index = 32, OtherProperty = "Group 3 / Index 32" },
        new MyObject{ GroupId = 3, Index = 32, OtherProperty = "Group 3 / Index 32" },
        new MyObject{ GroupId = 4, Index = 43, OtherProperty = "Group 4 / Index 43" },
        new MyObject{ GroupId = 4, Index = 42, OtherProperty = "Group 4 / Index 42" },
        new MyObject{ GroupId = 4, Index = 45, OtherProperty = "Group 4 / Index 45" },
        new MyObject{ GroupId = 4, Index = 46, OtherProperty = "Group 4 / Index 46" },
        new MyObject{ GroupId = 5, Index = 51, OtherProperty = "Group 5 / Index 51" },
        new MyObject{ GroupId = 5, Index = 54, OtherProperty = "Group 5 / Index 54" },
        new MyObject{ GroupId = 6, Index = 67, OtherProperty = "Group 6 / Index 67" },
        // ...                                                                    
        new MyObject{ GroupId = 6, Index = 63, OtherProperty = "Group 6 / Index 63" }
    }.AsQueryable();
    
    IQueryable<IGrouping<int, MyObject>> groups = objects.GroupBy(o => o.GroupId);
    
    IQueryable<MyObject> outcome = groups.Select(grouping => grouping.OrderBy(g => g.Index).First());
    
    List<MyObject> outcomeList = outcome.ToList();
    
    // outcomeList contains: 
    // new MyObject{ GroupId = 3, Index = 31, OtherProperty = "Group 3 / Index 31" };
    // new MyObject{ GroupId = 4, Index = 42, OtherProperty = "Group 4 / Index 42" };
    // new MyObject{ GroupId = 5, Index = 51, OtherProperty = "Group 5 / Index 51" };
    // new MyObject{ GroupId = 6, Index = 63, OtherProperty = "Group 6 / Index 63" };
