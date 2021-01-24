c#
customerPattern = andGroup.Pattern(typeof(RuleEngineRequestModel), item.Name);
customerParameter = customerPattern.Declaration.ToParameterExpression();
customerCondition =
    Expression.Lambda(
        Expression.GreaterThan(
            Expression.Property(customerParameter, item.FieldName),
            Expression.Constant(item.Value)),
        customerParameter);
customerPattern.Condition(customerCondition);
