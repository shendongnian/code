    var pensInShed = _db.Pens.Where(w => w.ShedId == selectedShedGuid).Select(s => s.PensGuid);
    foreach(var penId in pensInShed)
    {
        var shedTotal =
            _db.DailyConsumptionPens
                .Where(w => w.PenId == penId && w.Timestamp == ConvertedDate)
            .Sum(x =>
                _db.ConsumptionUnits
                    .Where(w =>
                        w.DailyConsumptionId == x.ConsumptionPenGuid)
                    .Sum(xx => xx.UnitNETWeight * xx.UnitsUsed)
            );
        
    
        var pensToUpdate = _db.DailyConsumptionPens
            .Where(w => w.PenId == penId && w.Timestamp == ConvertedDate)
            .ToList();
        foreach(var pen in pensToUpdate)
        {
            pen.TotalShedUsage = shedTotal;
            _db.SaveChanges();
        }
    }
