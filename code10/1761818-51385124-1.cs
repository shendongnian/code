    public IQueryable<Parent> ParentsChildNameMatches(IQueryable<Parent> parents, string word)
    {
        var childExpression = ChildNameMatches(word);
        Expression<Func<Parent, bool>> expression = p => childExpression.Invoke(p.Child);
        expression = expression.Expand();
        return parents.Where(expression);
    }
