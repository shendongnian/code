    [HttpGet]
    [EnableQuery]
    public async Task<Skill[]> GetFilteredODataList(ODataQueryOptions<Skill> q)
    {
        var skillsQuery = this._context.Skills.AsQueryable();
        if (q?.Filter != null)
        {
            skillsQuery = q.Filter.ApplyTo(skillsQuery, new ODataQuerySettings()) as IQueryable<Skill>;
        }
        return await skillsQuery.ToArrayAsync();
    }
