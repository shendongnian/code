    var data = _model.List.Select(c => new { id = c.Id, cell = new[] { 
        c.Id.ToString(),
        c.Login.ToString(),
        c.FirstName,
        c.LastName,
        c.IsActive.ToString()
    } }).ToArray();
