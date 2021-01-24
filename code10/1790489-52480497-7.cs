    public void UpdateTicket(int Id) {
        var ticket = _context.Tickets.Where(c => c.Id == Id).SingleOrDefault();  
        if (ticket == null) { /* no ticket? */ }
    
        using (ticket.BeginUpdate()) {
            tickets.Status = TicketStatus.Resolved;
            ticked.ResolvedAt = DateTime.UtcNow;
        }
    
        _context.SaveChanges();       
    }
