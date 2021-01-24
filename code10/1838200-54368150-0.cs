    //POST api/values
    public void Post([FromBody]User value)
    {
        // ensure only 4 characters in the string
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
