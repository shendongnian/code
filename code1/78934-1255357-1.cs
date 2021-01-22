    public static OrdersDataTable GetByOrderId( int id )
    {
        return  
           new Query(connection)
           .Table(x => Inflector.Pluralize(x.GetType())
           .Fields(x=> { x.OrderID, x.CustomerID, x.Description, x.Amount })
           .Equals(x=>x.OrderID, id)
           .Execute<OrdersDataTable>();
    }
