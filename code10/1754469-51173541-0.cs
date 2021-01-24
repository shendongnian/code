    var usersList= new [] {
     "User1",
     "User2"
    };
    
    var systemUserQuery = new QueryExpression{
        EntityName = SystemUser.EntityLogicalName,
        ColumnSet = new ColumnSet("fullname","domainname" ....), //explicitly retrieve attributes
        Criteria = {
            Conditions = {
                new ConditionExpression("fullname", ConditionOperator.In, userList)
            }
        }
    };
    
    var usersResponse = organizationService.RetrieveMultiple(systemUserQuery); 
    var systemUsers = usersResponse.Entities.Select(s => (SystemUser)s).ToArray();
