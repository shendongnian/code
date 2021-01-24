	void Main()
	{
	    var theObject = new object();
	    var v = new ValidatableObject<object>(theObject);
		Console.WriteLine(v.IsValid);
		v.Rules.Add(new ValidationRuleTrue<object>());
		Console.WriteLine(v.IsValid);
		v.Rules.Add(new ValidationRuleFalse<object>());
		Console.WriteLine(v.IsValid);
	}
