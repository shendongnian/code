    var container = new Container(c =>
    {
    	c.For<ICustomerFactory>().Use<CustomerFactory>();
		c.Scan(x =>
		{
			x.TheCallingAssembly();
			x.AddAllTypesOf(typeof(ICustomer))
				.NameBy(t => ((ICustomer)Activator.CreateInstance(t, new object[0], new object[0])).Id);
		});
    });
