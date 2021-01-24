    var result = from a in _entities.table1
             join b in _entities.table2 on new { a.Table1Id, a.Table1LevelId } equals new { Table1Id = b.Table2Id, Table1LevelId = b.Table2LevelId }                
             join c in _entities.Table3 on a.Table1Id equals c.Table1Id into cc from ccc in cc.DefaultIfEmpty()            
             where a.Valide == true 
             select new MeteringPointDetailModel
             {
                Table1Id = a.Table1Id,
                Table1Label = a.Label,
                IsActive = a.IsActive,                                     
                Table3Label = c.Label,                 
             };
    result = !string.IsNullOrWhiteSpace(query.Table3Label) ? result.Where(c => c.Table3Label.ToLower().Contains(query.Table3Label.ToLower())) : result;
    var table1Ids = await result.OrderBy(p => p.Table1Id)
                                .Select(p => p.Table1Id).Distinct()
                                .Skip(query.Page).Take(query.PageSize)
                                .ToListAsync();
    var data = await result.Where(p => table1Ids.Contains(p.Table1Id)).ToListAsync();
