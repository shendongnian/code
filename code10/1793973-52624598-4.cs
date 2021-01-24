    if (illustratorAgentId != null)
    {
        // Join the Illustrators table and test its AgentId.  Since we only need the book
        // and author, we can continue to project 'x'.
        query =
            from x in query
            join ill in _db.Illustrators on x.b.IllustratorId equals ill.IllustratorId
            where ill.AgentId == illustratorAgentId
            select x;
    }
