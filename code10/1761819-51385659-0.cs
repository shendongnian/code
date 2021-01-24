    public static IQueryable<Parent> ParentsChildNameMatches(IQueryable<Parent> parents, string word)
    {
        var childPredicate = ChildNameMatches(word);
        var parent = Expression.Parameter(typeof(Parent), "parent");
        var parentPredicate = Expression.Lambda<Func<Parent, bool>>(
            Expression.Invoke(
                childPredicate, 
                Expression.Property(parent, "Child")),
            parent);
        return parents.Where(parentPredicate);
    }
