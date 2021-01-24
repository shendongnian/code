    // all your MeasureIds that you need
    var mIds = new List<int> { 3, 4, 5 };
    var res = mIds.Aggregate(new List<int>(), (list, next) =>
    {
        if (!list.Any()) //need to initially fill list otherwise no intersection
            return measures
                .Where(m => m.MeasureId == mIds.First())
                .Select(m => m.FilterId)
                .ToList();
        return list
            .Intersect(measures.Where(m => m.MeasureId == next)
            .Select(m => m.FilterId))
            .ToList();
    });
