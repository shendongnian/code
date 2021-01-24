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
            }).ToList();//query will be executed on DB because of ToList()
    List<DtoClass> results = search.Select(mn =>
            {
                //Manipulating mn data 
                //call some custom method to cast Date
                string newDate = CastMiladi2Other(date);
                DtoClass ret = new DtoClass()
                { 
                    FullName = GetFullName(mn.Name, mn.LastName),
                    ShamsiDate = newDate,
                    GateId = mn.gate_id
                };
                return ret;
            }).ToList();
