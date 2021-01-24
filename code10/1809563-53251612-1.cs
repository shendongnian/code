    if (conditions.Any())
    {
    	var parameter = Parameter(typeof(History));
    	var body = conditions
            .Select(condition => Expression.Constant(condition))
            .Select(condition => Expression.AndAlso(
            Expression.Equal(
                Expression.PropertyOrField(parameter, nameof(History.IdReference)),
                Expression.Convert(
                      Expression.PropertyOrField(condition, nameof(Condition.IdReference))
                    , Expression.PropertyOrField(parameter, nameof(History.IdReference)).Type)
            ),
            Expression.Equal(
                Expression.PropertyOrField(parameter, nameof(History.TableName)),
                Expression.Convert(
                      Expression.PropertyOrField(condition, nameof(Condition.TableName))
                    , Expression.PropertyOrField(parameter, nameof(History.TableName)).Type)
             )
            ))
            .Aggregate(Expression.OrElse);                    	
    	var predicate = Lambda<Func<History, bool>>(body, parameter);
    	histories = histories.Where(predicate);
    }
