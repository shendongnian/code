	string url = "";
	List<ConditionBase> Conditions = new List<ConditionBase>();
	Conditions.Add(new Condition<int>(Field.Field1, 1, ConditionOperator.Equal));
	Conditions.Add(new Condition<string>(Field.Field2, "test", ConditionOperator.NotEqual));
	foreach (var c in Conditions.OfType<Condition<string>>())
	{
		url += c.Field + " " + c.ConditionOperator + " '" + c.Value + "' and ";
	}
