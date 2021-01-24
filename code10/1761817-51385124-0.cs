    public IQueryable<Parent> ParentsChildNameMatches(IQueryable<Parent> parents, string word)
    {
        Expression<Func<Parent, bool>> expression = p => ChildNameMatches(word).Invoke(p.Child);
    
        expression = expression.Expand();
    
        return parents.Where(expression);
    }
