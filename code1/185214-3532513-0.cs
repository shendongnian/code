    TicketsDataContext db = new TicketsDataContext();
    var query = from ticket in db.Tickets select ticket;
    If (param.Name == "Department"){
        if (!string.IsNullOrEmpty(param.Value)){
            query = query.Where(c => c.Department == param.Value);
         }
    }
    If (param.Name == "Category"){
        if (!string.IsNullOrEmpty(param.Value)){
            query = query.Where(c => c.Category == param.Value);
        }
    }
