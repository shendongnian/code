    using (var context = new DbContext())
    {
        var se = new SubscriptionError1()
        {
            FieldName1 = "Value",
            SubscriptionId = 1,
            //SubscriptionErrorId is auto 
        };
        context.SubscriptionError1.Add(se);
        context.SaveChanges();
    }
