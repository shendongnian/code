    var predicates = new List<IPredicate>
    {
    	Predicates.Field<TestCarModel>(f => f.Type, Operator.Eq, "Sedan"),
    	Predicates.Field<TestCarModel>(f => f.Type, Operator.Eq, "Hatchback"),
    };
    
    var testdata = PrepareTestData();
    var expression = PredicateParser<TestCarModel>.ParseOr(predicates).Compile();
    var result = testdata.Where(expression);
