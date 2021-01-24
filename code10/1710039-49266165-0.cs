    IQueryable<ClassA> itemsA = ...
    IQueryable<ClassB> itemsB = ...
    var innerJoinResult = itemsA.Join(itemsB,   // inner join A and B
        itemA => itemA.Id,                      // from each itemA take the Id
        itemB => itemB.Id,                      // from each itemB take the Id
        (itemA, itemB) => new                   // when they match make a new object
        {                                       // where you only select the properties you want
            NameA = itemA.Name,
            NameB = itemB.Name,
            BirthdayA = itemA.Birthday,
            ...
        });
