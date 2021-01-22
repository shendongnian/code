    private IQueryable<Task> FilterSeverities(IQueryable<Task> tasks)
    {
        if (Severities.Contains(TaskSearchConsts.All) || (!Severities.Any()))
            return tasks;
        var expressions = new List<Expression>();
        if (Severities.Contains(TaskSearchConsts.Active))
            expressions.Add(_taskParameter.EqualExpression("Severity.IsActive", 1));
        return tasks.WhereIn(_taskParameter, "Severity.ID", Severities, expressions);
    }
