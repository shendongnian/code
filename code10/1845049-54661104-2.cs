c#
public List<IRuleDefinition> BuildRule(List<RuleEngineEntity> list)
{
    var builder = new NRules.RuleModel.Builders.RuleBuilder();
    builder.Name("CustomerDetail");
    var orGroup = builder.LeftHandSide().Group(GroupType.Or);
    foreach (var item in list)
    {
        var andGroup = orGroup.Group(GroupType.And);
        var modelPattern = andGroup.Pattern(typeof(RuleEngineRequestModel), item.Name);
        var modelParameter = modelPattern.Declaration.ToParameterExpression();
        var customerData = Expression.Property(modelParameter, nameof(RuleEngineRequestModel.customerData));
        var customerCondition = Expression.Lambda(
            Expression.GreaterThan(
                    Expression.Property(customerData, item.FieldName),
                    Expression.Constant(item.Value)),
                modelParameter);
        modelPattern.Condition(customerCondition);
    }
    Expression<Action<IContext>> action =
        ctx => Console.WriteLine("Action triggered");
    builder.RightHandSide().Action(action);
    var rule = builder.Build();
    return new List<IRuleDefinition> {rule};
}
