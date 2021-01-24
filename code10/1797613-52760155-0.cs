    public List<string> GetProductCategories(int catno)
    {
        var parameter = Expression.Parameter(typeof(Category));
        var property = Expression.Property(parameter, $"Category{catno}");
        var selector = Expression.Lambda<Func<Category, string>>(property, parameter);
        using (var ctx = new myEntities())
        {
            return ctx.Categories
                .Select(selector)
                .ToList();
        }
}
