	string url = "";
	List<ConditionBase> Conditions = new List<ConditionBase>();
	Conditions.Add(new Condition<int>(Field.Field1, 1, ConditionOperator.Equal, (val)=> val.ToString()));
	Conditions.Add(new Condition<string>(Field.Field2, "test", ConditionOperator.NotEqual, (val)=> val));
	foreach (var c in Conditions)
	{
		url += c.Field + " " + c.ConditionOperator + " '" + c.ToString() + "' and ";
	}
