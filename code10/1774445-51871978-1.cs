    var result = dbContext.Orders
       .Where(order => ...)            // give me only the orders that ...
       .Select(order => new            // from every remaining order make one new object
       {                               // select only the properties you plan to use
            Id = order.Id,
            Name = order.Name,
            ...
            Requests = order.Requests
               .Where(request => ...)   // give me only the requests that ...
               .Select(request => new
               {                        // again: select only the properties you plan to use
                    Id = request.Id,
                    Name = request.Name,
                    ...
                    // not needed: OrderId = request.OrderId, you already know the value!
               })
               .ToList(),
       });
