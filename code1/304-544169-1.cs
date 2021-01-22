    MyDataContext db = new MyDataContext();
    IEnumerable<DataRow> query = (from order in db.Orders.AsEnumerable()
                                  select new
                                  {
                                     order.Property,
                                     order.Property2
                                  }) as IEnumerable<DataRow>;
    return query.CopyToDataTable<DataRow>();
