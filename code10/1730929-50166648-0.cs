        ColumnSet = new ColumnSet("productname"), 
        Criteria = new FilterExpression(LogicalOperator.And)
        {
            Conditions =
            {
                   new ConditionExpression("productstatus", ConditionOperator.Equal, 0)
            }
        },
        LinkEntities =
        {
            new LinkEntity("product", "phonecall", "productid", "regardingobjectid", JoinOperator.LeftOuter)
            {
                Columns = new ColumnSet("phonecallcategory"),
                LinkCriteria = new FilterExpression(LogicalOperator.And)
                {
                    Conditions =
                    {
                        new ConditionExpression("statecode", ConditionOperator.NotEqual, 0),
                        new ConditionExpression("phonecallcategory", ConditionOperator.Equal, "fun")
                    }
                }
            }
        }
    };
