    public string GetList(IEnumerable<TaskRelation> relations,
                          int taskId, int relTypeId,
                          Func<TaskRelation, string> projection)
    {
        var query = relations.Where(r => r.TaskId == taskId && 
                                         r.RelTypeID == relTypeId)
                             .Select(projection));
                             .ToArray()
        return string.Join("; ", query.ToArray());
    }
