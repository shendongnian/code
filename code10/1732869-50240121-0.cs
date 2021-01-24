    // used for my test:
    Shipment shipment1 = null;
    Shipment shipment2 = new Shipment { Id = 42, Consignor = new Address { Name = "Foo1", Street = "Bar1", Zip = "Baz1", City = "Qux1", Country = "Quux1" }, Consignee = new Address { Name = "Foo2", Street = "Bar2", Zip = "Baz2", City = "Qux2", Country = "Quux2" }, Invoices = new Invoice[] { new Invoice { Items = new Item[] { new Item { Description = "FooBar1", Amount = 1 }, new Item { Description = "BazQux1", Amount = 1 } } }, new Invoice { Items = new Item[] { new Item { Description = "FooBar2", Amount = 2 }, new Item { Description = "BazQux2", Amount = 2 } } } } };
    // kind of ugly but I didn't manage to do it prettier:
    shipment1 = Work(shipment2, shipment1);
    private T Work<T>(T source, T copy)
    {
        if (source == null)
            return copy;
        if (copy == null)
            copy = Activator.CreateInstance<T>();
        foreach (PropertyInfo prop in typeof(T).GetProperties())
        {
            switch (prop.PropertyType.Name.ToLower())
            {
                case "string":
                    string str = (string)prop.GetValue(source);
                    if (!string.IsNullOrEmpty(str))
                        if (string.IsNullOrEmpty((string)prop.GetValue(copy)))
                            prop.SetValue(copy, str);
                    break;
                case "int32":
                    int i = (int)prop.GetValue(source);
                    if (i != 0)
                        if ((int)prop.GetValue(copy) == 0)
                            prop.SetValue(copy, i);
                    break;
                case "address":
                    prop.SetValue(copy, Work(prop.GetValue(source) as Address, prop.GetValue(copy) as Address));
                    break;
                case "ienumerable`1":
                    switch (prop.PropertyType.GetGenericArguments()[0].Name.ToLower())
                    {
                        case "invoice":
                            IEnumerable<Invoice> invoices = (IEnumerable<Invoice>)prop.GetValue(source);
                            if (invoices != null && invoices.Count() > 0)
                                if ((IEnumerable<Invoice>)prop.GetValue(copy) == null)
                                    prop.SetValue(copy, invoices);
                            break;
                        // edit: this is actually useless
                        /*
                        case "item":
                            IEnumerable<Item> items = (IEnumerable<Item>)prop.GetValue(source);
                            if (items != null && items.Count() > 0)
                                if ((IEnumerable<Item>)prop.GetValue(copy) == null)
                                    prop.SetValue(copy, items);
                            break;
                        */
                    }
                    break;
            }
        }
        return copy;
    }
