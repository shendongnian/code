    public static IQueryable<ProductDTO> FilterAgeByGroup(
        IQueryable<ProductDTO> query, 
        List<string> filters)
    {
        var criteria = filters
            .Select(filter => {
                Items.TryGetValue(filter, out var criterion);
                return criterion; // if filter is not in Items.Keys, code will be 0
            })
            .Where(criterion => criterion.code > 0) // excludes filters not matched in Items
            .ToList();
        if (!criteria.Any()) { return query; }
        var type = typeof(ProductDTO);
        var x = Parameter(t);
        // creates an expression that represents the number of years old this ProductDTO is:
        // 2019 - x.YearManufactured
        var yearsOldExpr = Subtract(
            Constant(DateTime.UtcNow.Year),
            Property(x, t.GetProperty("YearManufactured"))
        );
        var filterExpressions = new List<Expression>();
        foreach (var criterion in criteria) {
            Expression minExpr = null;
            if (criterion.min != null) {
                // has to be at least criteria.min years old; eqivalent of:
                // 2019 - x.YearManufactured >= 10
                minExpr = GreaterThanOrEqual(
                    yearsOldExpr,
                    Constant(criterion.min)
                );
            }
            Expression maxExpr = null;
            if (criterion.max != null) {
                // has to be at least criteria.max years old; equivalent of
                // 2019 - x.YearManufactured <= 20
                maxExpr = LessThanOrEqual(
                    yearsOldExpr,
                    Constant(criterion.max)
                )
            }
            if (minExpr != null && maxExpr != null) {
                filterExpressions.Add(AndAlso(minExpr, maxExpr));
            } else {
                filterExpressions.Add(minExpr ?? maxExpr); // They can't both be null; we've already excluded that possibility above
            }
        }
        Expression body = filterExpressions(0);
        foreach (var filterExpression in filterExpressions.Skip(1)) {
            body = OrElse(body, filterExpression);
        }
        return query.Where(
            Lambda<Func<ProductDTO, bool>>(body, x)
        );
    }
