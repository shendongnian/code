    var query = new QueryExpression
    {
        EntityName = "list",
        ColumnSet = new ColumnSet(false)
    };
    query.Criteria.AddCondition("name", ConditionOperator.Equal, "new list 1";
    var matchingLists = _organizationService.RetrieveMultiple(query);
    var defaultListId = matchingLists?.Entities.FirstOrDefault()?.Id ?? Guid.Empty;
