            //Query for the GUID of the Account using Account Name
            QueryExpression query = new QueryExpression("account");
            string[] cols = { "accountid", "name" };
            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("name", ConditionOperator.Equal, "Account Name");
            query.ColumnSet = new ColumnSet(cols);
            var account = Service.RetrieveMultiple(query);
            //Casting the reference to GUID
            Guid accountId = (Guid)account[0].Attributes["accountid"];
