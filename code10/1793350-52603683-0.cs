    from c in session.Query<Category>
    select new CategoryDto {
      Name = c.Name, //and other properties
      SubCategories = c.SubCategories
        .Where(sc => !sc.Retired)
        .Select(sc => new SubCategoryDto { ... })
        .ToList()
    }
