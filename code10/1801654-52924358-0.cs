     IQueryable<???> items = ...             // collection of Listings?
     List<Listing> itemsSelected = null;    
     IQueryable<Category> enabledCategories = model.Categories.Where(category => category.Enabled));  
     foreach (Category category in enabledCategories)
     {                    
         IEnumerable<Category> itemsTemp = items
             .Select(item => item.Categories
                    .Where(tmpCategory => tmpCategory.ID == category.ID));
         foreach (Category item1 in itemsTemp)
         {
             // can't cast a Category to a Listing
