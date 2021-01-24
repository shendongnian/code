    var search = OdataBaseContex.TRD.GroupJoin(
            OdataBaseContex.Gates,
            f => f.gate_id,
            p => p.ID,
            (x, y) => new { TRD = x, gate = y })
    .SelectMany(
            x => x.gate.DefaultIfEmpty(),
            (x, y) => new
            {
                LastName = x.TRD.LastName,
                Name = x.TRD.Name, 
                gate_id = y.name
            }).ToList().Select(mn => new
            {
                LastName = mn.LastName,
                Name = mn.Name,
                DisplayFullName = GetFullName(mn.Name,mn.LastName)
                gate_id = mn.gate_id
            });
