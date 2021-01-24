	var predicateGroup = new PredicateGroup { Operator = GroupOperator.Or, Predicates = new List<IPredicate>() };
	foreach(int thisID in commaSeparatedListOfIDs)
	{
		var predicate = Predicates.Field<SomeTable>(f => f.Id, Operator.Eq, thisID);
		predicateGroup.Predicates.Add(predicate);
	}
	IEnumerable<SomeTable> list = cn.GetList<SomeTable>(predicateGroup);
