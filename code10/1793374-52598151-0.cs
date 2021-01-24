    public async Task<Tuple<List<IdNamePair>, int>> GetStudents(QueryFilter queryObject)
    {
        var query = studentEntity.Select(p => new IdNamePair
        {
            ID = p.ID.ToString(),
            Name = p.StudentNameSurname
        });
    
        int totalCount = await query.CountAsync();
    
        query = query.ApplyPaging(queryObject);//like Skip(20).Take(10)
    
        var students = await query.ToListAsync();
    
        return (students, totalCount);
    }
