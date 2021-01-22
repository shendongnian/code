        public partial class Category
        {
            public IEnumerable<Category> AllSubcategories()
            {
                yield return this;
                foreach (var directSubcategory in Subcategories)
                    foreach (var subcategory in directSubcategory.AllSubcategories())
                    {
                        yield return subcategory;
                    }
            }
        }
