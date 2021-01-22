    builder.Entity<Employee>().MapSingleType(e => new {
      e.Id,
      e.Name,
      e.FatherName,
      e.IsMale,
      e.IsMarried
    });
