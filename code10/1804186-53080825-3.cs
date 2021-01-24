    new[]
    {
    	new { Id = (object)DBNull.Value },
    	new { Id = (object)"whatever" }
    }
    .OrderBy(e => e.Id)
    .ToList(); // Fail
