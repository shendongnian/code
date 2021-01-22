    public IQueryable<Category> List(int startIndex, int count, IOrderByExpression<Category> ordering)
    {
        NorthwindEntities ent = new NorthwindEntities();
        IQueryable<Category> query = ent.Categories;
        if (ordering == null)
        {
          ordering = new OrderByExpression<Category, int>(c => c.CategoryID)
        }
        ordering.ApplyOrdering(ref query);
        return query.Skip(startIndex).Take(count);
    }
