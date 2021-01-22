    // First we define the parameter that we are going to use
    // in our OrderBy clause. This is the same as "(person =>"
    // in the example above.
    var param = Expression.Parameter(typeof(Person), "person");
    
    // Now we'll make our lambda function that returns the
    // "DateOfBirth" property by it's name.
    var mySortExpression = Expression.Lambda<Func<Person, object>>(Expression.Property(param, "DateOfBirth"), param);
    
    // Now I can sort my people list.
    Person[] sortedPeople = people.OrderBy(mySortExpression).ToArray();
