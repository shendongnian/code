            string result =                
                Enumerable.Repeat(order.UpdatedDate, 1)
                    .Concat(order.Orderlines.Select(x1 => x1.UpdatedDate))
                    .Concat(order.Orderlines.SelectMany(x => x.OrderLineSizes).Select(x => x.UpdatedDate))
                    .Concat(order.Orderlines.SelectMany(x => x.OrderLineValueAddedServices).Select(x => x.UpdatedDate))
                    .Max().ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
