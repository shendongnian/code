    private static EntityCollection GetEmails(IOrganizationService service, string entityName, ColumnSet cols)
        {
    
            QueryExpression query = new QueryExpression
            {
                EntityName = "email",
                Criteria = new FilterExpression
                {
                    //FilterOperator = LogicalOperator.And,
                    Conditions = {
                        new ConditionExpression {
                            AttributeName = "statuscode",
                            Operator = ConditionOperator.Equal,
                            Values = { 1 }
                        }
                    }
                },
                LinkEntities = {
                    new LinkEntity {
                        LinkFromEntityName = "email",
                        LinkFromAttributeName = "activityid",
                        LinkToEntityName = "activityparty",
                        LinkToAttributeName = "activityid",
                        LinkCriteria = new FilterExpression {
                            FilterOperator = LogicalOperator.And,
                            Conditions = {
                                new ConditionExpression {
                                    AttributeName = "addressused",
                                    Operator = ConditionOperator.Like,
                                    Values = { "%" + "agus@yahoo" + "%" }
                                }
                            }
                        }
                    }
                }
       
            };
            return service.RetrieveMultiple(query);
        }
