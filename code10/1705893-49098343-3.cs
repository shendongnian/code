    return stats
       .GroupBy(x => x.Id)
       .OrderByDescending(x => x.Sum(a => a.Kills))
       // paginatation
       .Skip(pageNumber * pageSize)
       .Take(pageSize)
       // pull paged result set into memory to make life easy
       .ToList()
       // transform into WeaponItem
       .Select(x => new WeaponItem
       {         
            PossessionTime = new TimeSpan(x.Sum(p => p.PossessionTime.Ticks))
       });
