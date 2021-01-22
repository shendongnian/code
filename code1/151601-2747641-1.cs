    // Ways of defining an entity sorter
    // 1. Using strings:
    IEntitySorter<Person> sorter = EntitySorter<Person>
        .OrderBy("Address.City")
        .ThenByDescending("Id");
    // 2. Defining a sorter with lambda's
    IEntitySorter<Person> sorter = EntitySorter<Person>
        .OrderByDescending(p => p.Name)
        .ThenBy(p => p.Id)
        .ThenByDescending(p => p.Address.City);
    // 3. Using a LINQ query
    IEntitySorter<Person> sorter =
        from person in EntitySorter<Person>.AsQueryable()
        orderby person.Name descending, person.Address.City
        select person;
    // And you can pass a sorter from your presentation layer
    // to your business layer, and you business layer may look
    // like this:
    static Person[] GetAllPersons(IEntitySorter<Person> sorter)
    {
        using (var db = ContextFactory.CreateContext())
        {
            IOrderedQueryable<Person> sortedList =
                sorter.Sort(db.Persons);
    
            return sortedList.ToArray();
        }
    }
