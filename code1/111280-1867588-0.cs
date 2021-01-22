    string[] usernames;
    string[] rolenames;
    
    UserRoleCollection userRoles = new UserRoleCollection ();
    PredicateExpression filter = new PredicateExpression();
    filter.Add(new FieldCompareRangePredicate(UserFields.logincode, usernames));
    filter.AddWithAnd(new FieldCompareRangePredicate(RoleFields.Name, rolenames));
    userRoles.DeleteMulti(filter)
