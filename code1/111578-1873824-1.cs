    var SubTotals = from o in ord
                    group o by o.OrderDate.Date into g
                        select new
                                   {
                                       Id = g.Max(x => x.OrderNumber),
                                       Amount = g.Sum(x => x.OrderAmount)
                                   };
    var qry = from o in ord
              orderby o.OrderDate
              let subTotals = SubTotals.Where(x => x.Id == o.OrderNumber)
              let grandTotal = ord.Sum(x => x.OrderAmount)
              let lastId = ord.OrderBy(x => x.OrderNumber).Last().OrderNumber
              select
                  new
                      {
                          OrderNumber = o.OrderNumber,
                          OrderDate = o.OrderDate.Date,
                          Amount = o.OrderAmount,
                          SubTotal = (subTotals.Any()
                                        ? subTotals.First().Amount.ToString()
                                        : "***"),
                          GrandTotal = (o.OrderNumber == lastId
                                        ? grandTotal.ToString()
                                        : "***")
                      };
