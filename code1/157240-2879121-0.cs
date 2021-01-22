    public static List<SubCategory> GetAlphabetizedSubCategories(this Category category)
    {
        return category.SubCategories
            .OrderBy(sc => sc.Name)
            .ToList();
    }
