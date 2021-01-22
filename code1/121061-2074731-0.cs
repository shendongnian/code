          public EntityCollection<Category> SortedSubCategories
            {
                get
                {
                    return SubCategories.OrderBy(p => p.Name);
                }
            }
