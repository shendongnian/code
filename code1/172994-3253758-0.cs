    public void InsertAll(List<MyClass> items) {
       var itemsAsCustomers = items.Select(item => new TBL_Customer
       {
          ID = item.UserID,
          Username = item.UsernamePropertyOnMyClass,
       });
    
       db.TBL_Customers.InsertAllOnSubmit(itemsAsCustomers);
       db.SubmitChanges();
    }
