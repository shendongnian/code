    var ticketList = (from T in db.Tickets
                      where  T.Title.Contains("a")
                      select new TicketSummary {
                            CustomerName = (
                               from cname in db.Customers
                               where cname.CustomerId == T.CustomersId
                               select cname.FirstName + cname.LastName
                            ) ,
                            Title = T.Title
                      }).ToList();
