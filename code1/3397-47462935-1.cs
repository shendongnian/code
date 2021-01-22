      public IQueryable<Order> GetOrdersAsQuerable()
        {
            IEnumerable<Order> qry= GetOrders();
			//use the built-in extension method  AsQueryable in  System.Linq namespace
            return qry.AsQueryable();            
        }
