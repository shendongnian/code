    ISQLQuery query = session.CreateSQLQuery(
                    "select c.* " +
                    "from Customer c " +
                    "where c.CreateDate > :CreateDate");
    query.SetDateTime("CreateDate", new DateTime(2009, 3, 14));
    query.AddEntity(typeof(Customer));
    IList<Customer> results = query.List<Customer>();
