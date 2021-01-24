    private IQueryable<Order> GetIncludes(MyEntities context)
    {
      return context.Orders
       .Include("Customers")
       .Include("Products")
       .Include("OrderLines");
    }
