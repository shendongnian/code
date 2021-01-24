    public async Task<Tuple<List<IdNamePair>>, int> GetStudents(QueryFilter queryObject)
    {
      var query = studentEntity.Select(p => new IdNamePair
      {
        ID = p.ID.ToString(),
        Name = p.StudentNameSurname
      }).ToListAsync();
      int totalCount = await query.CountAsync();
      query = query.ApplyPaging(queryObject);//like Skip(20).Take(10)
      var students = await query.ToListAsync();
      return new Tuple<List<IdNamePair>, int>(students, totalCount); //ERROR
    }
