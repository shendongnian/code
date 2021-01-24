    using (var context = new DbContext())
    {
        var se = new SubscriptionError()
        {
            FieldName1 = "Value",
            SubscriptionId = 1,//Parent key
            //SubscriptionErrorId is auto 
        };
        context.SubscriptionError1.Add(se);
        context.SaveChanges();
    }
