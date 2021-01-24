    public async Task<IEnumerable<SearchSelect>> SelectInfoByName(string info)
    {
        var infoByName = searchInfoRepo.SearchInfoByName(info);
        return await Task.Result(infoByName.Select(info => new SearchSelect
        {
            text = info.Name,
            value = info.InfoId
        }).ToListAsync());
    }
