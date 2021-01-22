    var qry = Queryable.Select(
                  Queryable.Where(
                      ctx.Customers,
                      cust => cust.Region == "North"),
                  cust => new { cust.Id, cust.Name });
