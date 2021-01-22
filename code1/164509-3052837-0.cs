    ColumnSet columns = new ColumnSet();
    columns.Attributes = new string[]{ "event_name", "eventid", "startdate", "city" };
    
    ConditionExpression eventname1 = new ConditionExpression();
    eventname1.AttributeName = "event_name";
    eventname1.Operator = ConditionOperator.Equal;
    eventname1.Values = new string[] { "Event A" };
    
    ConditionExpression eventname2 = new ConditionExpression();
    eventname2.AttributeName = "event_name";
    eventname2.Operator = ConditionOperator.Equal;
    eventname2.Values = new string[] { "Event B" };
    
    FilterExpression filter = new FilterExpression();
    filter.FilterOperator = LogicalOperator.Or;
    filter.Conditions = new ConditionExpression[] { eventname1, eventname2 };
    
    QueryExpression query = new QueryExpression();
    query.ColumnSet = columns;
    query.EntityName = EntityName.mbs_event.ToString();
    query.Criteria = filter;
    
    RetrieveMultipleRequest request = new RetrieveMultipleRequest();
    request.Query = query;
    
    return (RetrieveMultipleResponse)crmService.Execute(request);
