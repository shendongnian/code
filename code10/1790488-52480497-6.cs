    public void UpdateTicket(int Id) {
        var ticket = _context.Tickets.Where(c => c.Id == Id).SingleOrDefault();  
        if (ticket == null) { /* no ticket? */ }
    
        ticket.BeginUpdate();
        tickets.Status = TicketStatus.Resolved;
        ticked.ResolvedAt = DateTime.UtcNow;
        ticket.EndUpdate();
    
        _context.SaveChanges();       
    }
