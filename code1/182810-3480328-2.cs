    var contacts = parties.Select(p => new Contact {
        Type = p.Type,
        Name = p.Name,
        Status = p.Status
    });
        
