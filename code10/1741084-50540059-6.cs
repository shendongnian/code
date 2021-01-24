    var query = entities.AsQueryable()
      .GroupJoin(
        others.AsQueryable(),
        p => p.id,
        o => o.entity,
        (p, o) => new { p.id, p.name, other = o }
      )
      .SelectMany(p => p.other, (p, other) => new { p.id, p.name, other })
      .OrderByDescending(p => p.other.name);
