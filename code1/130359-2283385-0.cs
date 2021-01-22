    var ordering = CustomerIDs.ToList();
    var query = db.Customer.Join( db.Order, (a,b) => a.CustomerID == b.CustomerID )
                           .AsEnumerable()
                           .OrderBy( j => ordering.IndexOf( j.Customer.CustomerID ) )
                           .Select( j => new CustomerOrderData {
                              // do selection
                            })
                           .ToArray();
