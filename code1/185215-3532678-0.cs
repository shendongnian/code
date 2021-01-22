    TicketsDataContext db = new TicketsDataContext();
    var query = from ticket in db.Tickets 
                where ticket.Department == (!string.IsNullOrEmpty(DepartmentParam.Value) ? DepartmentParam.Value : ticket.Department) &&
                      ticker.Category == (!string.IsNullOrEmpty(CategoryParam.Value) ? CategoryParam.Value : ticket.Category)
                select ticket;
