    Expression<Func<Project, bool>> predicate = p => p.ProjectDescription.Contains(search);
    if (isID)
    {
        ParameterExpression param = expr.Body.Parameters[0];
        predicate = Expression.Lambda<Func<Project, bool>>(
            Expression.Or(
                expr.Body,
                Expression.Equal(
                    Expression.Property(param, "ProjectID"),
                    Expression.Constant(projectID))),
            param);
    }
    var projects = dataContext.Projects.Where(predicate);
