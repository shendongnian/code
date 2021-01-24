    public static class Extensions
    {
        public static IRuleBuilderInitial<T, TProperty> When<T, TProperty>(this IRuleBuilderInitial<T, TProperty> rule, Func<T, bool> predicate, ApplyConditionTo applyConditionTo = ApplyConditionTo.AllValidators)
        {
            return rule.Configure(config =>
            {
                PropertyRule propertyRule = config;
                int num = (int)applyConditionTo;
                propertyRule.ApplyCondition(ctx => predicate((T)ctx.InstanceToValidate), (ApplyConditionTo)num);
            });
        }
    
        public static IRuleBuilderInitial<T, TProperty> Custom<T, TProperty, TProperty2>(this IRuleBuilder<T, TProperty> ruleBuilder, Expression<Func<TProperty, TProperty2>> expression, AbstractValidator<TProperty2> validator)
        {
            var propChain = PropertyChain.FromExpression(expression);
            var propName = propChain.ToString();
            var prop = expression.Compile();
    
            Func<string, string, string> joinStr = (s1, s2) => string.Join(".", new[] { s1, s2 }.Where(s => !string.IsNullOrEmpty(s)));
            return ruleBuilder.Custom((p, context) =>
            {
                var val = prop(p);
                var validationResult = validator.Validate(val);
                propName = joinStr(context.PropertyName, propName);
    
                foreach (var failure in validationResult.Errors)
                {
                    failure.PropertyName = joinStr(propName, failure.PropertyName);
                    context.AddFailure(failure);
                }
            });
        }
    }
    
    RuleFor(p => p).Custom(p => p.MainProperty, new MainPropertyValidator()).When(p =>
      {
          var checkMainProperty = p.MainProperty.Id != -1;
          if (!checkMainProperty)
          {
              // Some actions...
          }
    
          return checkMainProperty;
      });
