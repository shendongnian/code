        public Array GetTotalResearchByArea()
        {
            var list = new List<int>();
            var all_area = context.Areas.Select(x => x.Id ).ToList();
            foreach( var item in all_area)
            {
                var AllReserachCategory = context.ResearchCategories.Where(a => a.AreaId == item).Select(a => a.Id).ToList();
                var TotalResearchbySingleArea = context.Researchs.Where(c => AllReserachCategory.Contains(c.ResearchCategoryId)).Count();
                list.Add(TotalResearchbySingleArea);
            }
            return list.ToArray();
        }
