    var objCust = new[]
    {
     new {CustID = 2, CustName = "Sumitra", Phone = "123-123-1236"},
     new {CustID = 3, CustName = "Wriju", Phone = "123-123-1235"},
     new {CustID = 4, CustName = "Writam", Phone = "123-123-1234"},
     new {CustID = 1, CustName = "Debajyoti", Phone = "123-123-1237"}   
    };
    XElement _customers = new XElement("customers",
                            from c in objCust
                            orderby c.CustID //descending 
                            select new XElement("customer",
                                new XElement("name", c.CustName),
                                new XAttribute("ID", c.CustID),
                                new XElement("phone", c.Phone)
                                                )
                                        );
    Console.WriteLine(_customers);
