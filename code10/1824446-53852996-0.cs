    // Instantiate QueryExpression QEemail
    var QEemail = new QueryExpression("email");
    QEemail.TopCount = 50;
    
    // Add columns to QEemail.ColumnSet
    QEemail.ColumnSet.AddColumns("activityid", "activitytypecode");
    
    // Define filter QEemail.Criteria
    QEemail.Criteria.AddCondition("activitytypecode", ConditionOperator.Equal, 4202);
    
    // Add link-entity QEemail_activityparty
    var QEemail_activityparty = QEemail.AddLink("activityparty", "activityid", "activityid");
    
    // Add columns to QEemail_activityparty.Columns
    QEemail_activityparty.Columns.AddColumns("addressused");
    
    // Define filter QEemail_activityparty.LinkCriteria
    QEemail_activityparty.LinkCriteria.AddCondition("addressused", ConditionOperator.Like, "%arunvinoth%");
