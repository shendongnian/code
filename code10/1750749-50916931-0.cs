    var counts = await this.context.Models
        .Select(e => new { Revoked = e.IsRevoked ? 1 : 0 })
        .GroupBy(e => 1)
        .Select(g => new ViewModel
        {
            Count = g.Count(),
            Revoked = g.Sum(e => e.Revoked)
        })
        .ToArrayAsync();
