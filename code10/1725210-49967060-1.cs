    private static IQueryable<MultiframeModule> WhereAllFramesProperties(this IQueryable<MultiframeModule> query, ICollection<Frame> frames)
    {
        var parameter = Expression.Parameter(typeof(MultiframeModuleFrame), "e");
        var body = frames.Select((frame, index) =>
        {
        	Expression<Func<Frame, bool>> predicate = e => e.FrameData.ShaHash == frame.FrameData.ShaHash;
        	return new
        	{
        		Condition = predicate.Body.ReplaceParameter(predicate.Parameters[0], parameter),
        		Value = Expression.Constant(index)
        	};
        })
        .Reverse()
        .Aggregate((Expression)Expression.Constant(-1), (next, item) =>
        	Expression.Condition(item.Condition, item.Value, next));
        var selector = Expression.Lambda<Func<Frame, int>>(body, parameter);
        var count = frames.Count();
        return query.Where(p => p.Frames.AsQueryable().Select(selector)
            .Distinct().Count(i => i >= 0) == count);
    }
