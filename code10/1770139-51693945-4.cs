    List<SqlParameter> pc = new List<SqlParameter>
    {
       new SqlParameter("@customerOrderID", customerProductDelivery.CustomerOrderI),
       new SqlParameter("@qty", customerProductDelivery.DeliveryQty)
    }
    
    _context.Database.ExecuteSqlQuery("sp_UpdateProductOrderAndStock @customerOrderID, @qty", pc.ToArray());
