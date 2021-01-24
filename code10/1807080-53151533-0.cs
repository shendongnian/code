    List<Person> totalPerson = new List<Person> {
        new Person{  Id = 1,CreateTime = new DateTime(2018,10,2)},
        new Person{  Id = 2,CreateTime = new DateTime(2018,10,3)},
        new Person{  Id = 3,CreateTime = new DateTime(2018,10,4)},
        new Person{  Id = 4,CreateTime = new DateTime(2018,10,6)},
        new Person{  Id = 5,CreateTime = new DateTime(2018,10,7)},
        new Person{  Id = 6,CreateTime = new DateTime(2018,10,8)},
        new Person{  Id = 7,CreateTime = new DateTime(2018,10,11)},
        new Person{  Id = 8,CreateTime = new DateTime(2018,10,12)},
        new Person{  Id = 9,CreateTime = new DateTime(2018,10,13)},
        new Person{  Id = 10,CreateTime = new DateTime(2018,10,16)},
        new Person{  Id = 11,CreateTime = new DateTime(2018,10,17)},
        new Person{  Id = 12,CreateTime = new DateTime(2018,10,18)}
    };
    List<Tuple<DateTime, DateTime>> ranges = new List<Tuple<DateTime, DateTime>>{
        new Tuple<DateTime, DateTime>(new DateTime(2018,10,1), new DateTime(2018,10,5)),
        new Tuple<DateTime, DateTime>(new DateTime(2018,10,10), new DateTime(2018,10,15))
    };
    
    IQueryable<Person> persons = totalPerson.Where(t => t.Id > 0).AsQueryable();
    var parameter = Expression.Parameter(typeof(Person), "t");
    BinaryExpression binaryExpression = null;
    
    ranges.ForEach(range =>
    {
        MemberExpression filed = Expression.PropertyOrField(parameter, "CreateTime");
        var startTime = Expression.Constant(range.Item1);
        var endTime = Expression.Constant(range.Item2);
        var expressionItem1 = Expression.GreaterThanOrEqual(filed, startTime);
        var expressionItem2 = Expression.LessThanOrEqual(filed, endTime);
        var expressionItem = Expression.And(expressionItem1, expressionItem2); ;
        if (binaryExpression == null)
        {
            binaryExpression = expressionItem;
        }
        else
        {
            binaryExpression = Expression.Or(binaryExpression, expressionItem);
        }
    });
    Expression<Func<Person, bool>> condition = Expression.Lambda<Func<Person, bool>>(binaryExpression, parameter);
    
    var results = persons.Where(condition);
