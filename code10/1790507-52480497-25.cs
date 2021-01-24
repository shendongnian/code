    void Close() {
        tickets.Status = TicketStatus.Resolved;
        ticked.ResolvedAt = DateTime.UtcNow;
        Validate();
    }
