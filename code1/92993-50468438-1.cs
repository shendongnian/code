        public List<Category> GetAllChildCats(int rootId)
        {
            List<Category> list = new List<Category>();
            Traverse(rootId);
            return list;
            void Traverse(int categoryId)
            {
                Category c = Get(categoryId);
                list.Add(c);
                foreach (Category cat in c.ChildCategories)
                {
                    Traverse(cat.CategoryID);
                }
            }
        }
