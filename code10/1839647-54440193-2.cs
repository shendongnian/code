    public static Expression<Func<T, T, bool>> CreateAreEqualExpression<T>(
      params Expression<Func<T, object>>[] toExclude)
    {
        var exclude = toExclude
            .Select(e =>
            {
                // for properties that is value types (int, DateTime and so on)
                var name = ((e.Body as UnaryExpression)?.Operand as MemberExpression)?.Member.Name;
                if (name != null)
                    return name;
                // for properties that is reference type
                return (e.Body as MemberExpression)?.Member.Name;
            })
            .Where(n => n != null)
            .Distinct()            
            .ToArray();
        var type = typeof(T);
        var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => !exclude.Contains(p.Name))
            .ToArray();
        /* rest of code is unchanged */
    }
    
