    public class TicketSummary
    {
         public string CustomerName { get; set; }
         public string Title { get; set; }
    }
    
    var ticketList = (from t in db.Tickets
                      where  t.Title.Contains("a")
                      select new TicketSummary
                      {
                          CustomerName = (
                              from cname in db.Customers
                              where cname.CustomerId == t.CustomersId
                              select cname.FirstName.ToString()
                          ).FirstOrDefault(),
                          Title = t.Title
                      }).ToList();
    return ticketList;
           
