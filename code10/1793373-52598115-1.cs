    public async Task<Tuple<List<IdNamePair>, int>> GetStudents(QueryFilter queryObject)
    {
        var query = studentEntity.Select(p => new IdNamePair
        {
            ID = p.ID.ToString(),
            Name = p.StudentNameSurname
        });
        int totalCount = await query.CountAsync();
        var students = await query.ApplyPaging(queryObject).ToListAsync();
        return new Tuple<List<IdNamePair>, int>(students, totalCount); 
    }
