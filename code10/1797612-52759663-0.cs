    public List<string> GetProductCategories(int catno)
    {
        using (var ctx = new myEntities())
        {
            switch (catno)
            {
                case 1:
                    return ctx.Categories.Select(c => c.Category1).ToList();
                case 2:
                    return ctx.Categories.Select(c => c.Category2).ToList();
                default:
                    throw new ArgumentException("Category number not supported!");
            }
        }
    }
