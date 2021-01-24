    public override async Task<PagedResultDto<PracticeDto>> GetAll(PagedAndSortedResultRequestDto input)
    {
        CheckGetAllPermission();
        var query = CreateFilteredQuery(input).AsNoTracking(); // Here!
        var totalCount = await AsyncQueryableExecuter.CountAsync(query);
        query = ApplySorting(query, input);
        query = ApplyPaging(query, input);
        var entities = await AsyncQueryableExecuter.ToListAsync(query);
        return new PagedResultDto<PracticeDto>(
            totalCount,
            entities.Select(MapToEntityDto).ToList()
        );
    }
