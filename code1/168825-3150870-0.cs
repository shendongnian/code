    var customer = ctx.Where(...).SingleOrDefault();
    if (customer == null)
    {
      customer = new Customer()
      {
        Name = name,
        Email = email
      };
      customerTable.InsertOnSubmit(customer);
    }
    else
    {
      customer.Name = name;
      customer.Email = email;
    }
    ctx.SubmitChanges();
