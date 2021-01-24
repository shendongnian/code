    using (var db = new MainContext())
    {
        // disconnected record
        var account = new Account()
        {
            Id = accountId,
            AccountNumber = "9876",
            Customer = new Customer() {Id = customerId}
        };
        db.Entry(account).State = EntityState.Modified; // <-- enough
        db.SaveChanges();
    }
 
