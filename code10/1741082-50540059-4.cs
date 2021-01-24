    var query = entities.AsQueryable()
        .GroupJoin(
          others.AsQueryable(),
          p => p.id,
          o => o.entity,
          (p, o) => new { p.id, p.name, other = o.First() }
        )
        .OrderByDescending(p => p.other.name);
