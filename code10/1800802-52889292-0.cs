    private async Task DeleteUnitsCascade(int unitID) {
      var workQueue = new Queue<int>();
      workQueue.Enqueue(unitID);
      while( workQueue.Count > 0 )
      {
         int _unitID = workQueue.Dequeue();
         var units = await _context.Units
                                   .Where(u => u.ParentID == _unitID &&
                                               u.FromDate <= DateTime.Now &&
                                               (u.ToDate == null || u.ToDate >= DateTime.Now))
                                   .GroupBy(unit => unit.UnitID)
                                   .Select(grouping => grouping.OrderByDescending(unit => unit.Version).FirstOrDefault())
                                   .ToListAsync();
          if (!units.Any()) continue;
          foreach (var unit in units) {
            var entityEntry = _context.Units.Attach(unit);
            entityEntry.Entity.ToDate = DateTime.Now;
            entityEntry.Entity.Position = 0;
            workQueue.Enqueue(unit.UnitID);
          }
      }
    }
