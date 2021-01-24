    private long _lastId;
    public IEnumerable<Students> GetPage(int toTake)
    {
        List<Students> result;
        result = isFirstPage
            ? _context.Students
                .Take(toTake)
                .ToList();
            : _context.Students
                .Where(s => s.Id > _lastId)
                .Take(toTake)
                .ToList();
        _lastId = result.LastOrDefault()?.Id ?? 0;
        return result;
    }
