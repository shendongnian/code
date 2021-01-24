    var p0 = new SqlParameter("@customerOrderID", customerProductDelivery.CustomerOrderID);
            var p1 = new SqlParameter("@qty", customerProductDelivery.DeliveryQty);
            _context.Database.ExecuteSqlCommand("sp_UpdateProductOrderAndStock @customerOrderID, @qty", p0, p1);
            //or  var p0 = new SqlParameter("@p0", customerProductDelivery.CustomerOrderID);
            //or  var p1 = new SqlParameter("@p1", customerProductDelivery.DeliveryQty);
            // or _context.Database.ExecuteSqlCommand("sp_UpdateProductOrderAndStock @p0, @p1", p0, p1); 
