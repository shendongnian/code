    //POST api/values
    public void Post([FromBody]User value)
    {
        // check for numbers only
        if (!Regex.IsMatch(value.CreditCardNumberLastFour, @"^\d+$")
        {
    		return;
    	}
        // ensure length is 4
    	if (value.CreditCardNumberLastFour.Length != 4)
    	{
    		return;
    	}
    	using (var db = new MembershipContext())
    	{
    		value = new User();
    		db.Users.Add(value);
    		db.SaveChanges();
    	}
    }
