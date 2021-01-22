    public static class MyExtentsions {
        public IQueryable<string> GetItemDescriptions(this Table<CN_MaintItem> table, int cat)
        {
            return from x in table
                   where x.CategoryID == cat
                   select x.ItemDescription;
        }
    }
