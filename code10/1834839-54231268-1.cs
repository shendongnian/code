    public Array GetTotalResearchByArea()
    {
        var list = new List<int>();
        var all_area = context.Areas.Select(x => x.Id ).ToList();
    
        foreach( var item in all_area)
        {
            var allReserachCategory = context.ResearchCategories.Where(a => a.AreaId == item).Select(a => a.Id).ToList();
            var totalResearchBySingleArea = context.Researchs.Where(c => allReserachCategory.Contains(c.ResearchCategoryId)).Count();
            list.Add(totalResearchBySingleArea);
        }
        return list.ToArray();
    }
