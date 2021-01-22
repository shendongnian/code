    public sealed class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table("Categories");
			CompositeId()
				.KeyProperty(c => c.ItemId, "ItemId")
				.KeyProperty(c => c.CategoryId, "CategoryId");
        }
    }
