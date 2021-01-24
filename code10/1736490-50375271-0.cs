    public async Task<List<MyViewModel>> getGoodElections(long actionId)
    {
        var elections = await _DBsource.ElectionTable.Where(e => e.ActionId == actionId && e.Status == "OK").ToListAsync();
        List< MyViewModel > list = Mapper.Map<List<MyViewModel>>(elections);
        return list;
    
    }
