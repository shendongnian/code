    public async Task CheckIds(IEnumerable<int> formIdList)
    {
        var results = formIdList.Select(id => _userAccessService.HasAccessToFormId(id)).ToList();
        while (results.Any())
        {
            var result = await Task.WhenAny(results);
            results.Remove(result);
            var authorized = await result;
            if (!authorized) throw new UnauthorizedAccessException();
        }
    }
