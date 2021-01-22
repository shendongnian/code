            public void AddCategory(Category category)
            {
                NorthWindDataContext dataContext = new NorthWindDataContext();
                try
                { 
                 dataContext.Categories.InsertOnSubmit(category);
                 dataContext.SubmitChanges();
                }
                catch (Exception) { }
            } 
