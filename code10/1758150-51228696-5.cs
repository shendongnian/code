	void Main()
	{
	    var theObject = new object();
	    var v = new ValidatableObject<object>(theObject);
		var subscription = v.IsValid.Subscribe(isValid => Console.WriteLine(isValid));
		var rule1 = v.AddRule(new ValidationRuleTrue<object>());
		var rule2 = v.AddRule(new ValidationRuleFalse<object>());
		rule2.Dispose(); //remove `rule2`
	}
