    using(var dc = new TestDC())
    {
        var cust = new Customer();
        cust.Name = "Jack";
        dc.InsertOnSubmit(cust);
        
        SubmitChanges();  //  cust.Id will be updated with a new generated value
    }
