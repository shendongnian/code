    // construct the query
    var a = from oi in db.OrderItems
            where oi.OrderID == ID
                && oi.ListingID != null
            select new {
                type = "A"
                item = oi
            }
    
    var b = from oi in db.OrderItems
            where oi.OrderID == ID
                && oi.AdID != null
            select new {
                type = "B"
                item = oi
            }
    
    var temp = a.Concat<OrderItem>(b);
    
    // create concrete types after concatenation
    // to avoid inheritance issue
    var result = from oi in temp
                 select (oi.type == "A"
                     ? (new OrderItemA {
                             // OrderItemA projection
                         } as OrderItem)
                     : (new OrderItemB {
                             // OrderItemB projection
                         } as OrderItem)
                 );
    
    return result
