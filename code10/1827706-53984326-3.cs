    var search = OdataBaseContex.TRD.GroupJoin(
            OdataBaseContex.Gates,
            f => f.gate_id,
            p => p.ID,
            (x, y) => new { TRD = x, gate = y })
    .SelectMany(
            x => x.gate.DefaultIfEmpty(),
            (x, y) => new {
                LastName = x.TRD.LastName,
                Name = x.TRD.Name,
                DisplayFullName = x.TRD.Name+"-"+x.TRD.LastName,   
                gate_id = y.name
            }).ToList(); 
