    var groupPredicate = new PredicateGroup
    {
    	Operator = GroupOperator.Or,
    	Predicates = new List<IPredicate>()
    };
    
    var predicateGroup1 = new PredicateGroup
    {
    	Operator = GroupOperator.Or,
    	Predicates = new List<IPredicate>()
    	{
    		Predicates.Field<TestCarModel>(f => f.Model, Operator.Eq, "500"),
    		Predicates.Field<TestCarModel>(f => f.Model, Operator.Eq, "Bravo")
    	}
    };
    
    var predicateGroup2 = new PredicateGroup
    {
    	Operator = GroupOperator.Or,
    	Predicates = new List<IPredicate>()
    	{
    		Predicates.Field<TestCarModel>(f => f.Name, Operator.Eq, "Opel"),
    		Predicates.Field<TestCarModel>(f => f.Type, Operator.Eq, "Hatchback"),
    	}
    };
    
    groupPredicate.Predicates.Add(Predicates.Field<TestCarModel>(f => f.Cost, Operator.Gt, 35000));
    groupPredicate.Predicates.Add(predicateGroup1);
    groupPredicate.Predicates.Add(predicateGroup2);
    
    
    var testdata = PrepareTestData();
    var expression = PredicateParser<TestCarModel>.Parse(groupPredicate).Compile();
    var result = testdata.Where(expression);
