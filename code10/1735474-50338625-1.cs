    var ans = table.Select(a => new { b = a.TotalPrice / a.Quantity, a })
                   .Where(ba => ba.b > 500)
                   .Select(ba => new {
                       PriceEa = ba.b,
                       ba.a.ID,
                       ba.a.Description
                    });
