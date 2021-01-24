    public void UpdateTicket(int Id) {
        var ticket = _context.Tickets.Where(c => c.Id == Id).SingleOrDefault();  
        if (ticket == null) { /* no ticket? */ }
        ticket.Close();
   
        _context.SaveChanges();       
    }
