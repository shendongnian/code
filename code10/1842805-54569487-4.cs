    public async Task<JsonResult> IsSubCategoryExist(string Name, int? ID, string ClassName)
    {
          var type = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(t => t.Name == ClassName);
    
          if (type != null)
          {
             DbSet dbSet = _dbContext.Set(type);
             List<object> subCategories;
             if(ID == null)
             {
                 subCategories = await dbSet.Where("Name == @0", Name) 
                                            .Take(1).ToListAsync();
             }
             else
             {
                 subCategories = await dbSet.Where("Name == @0 and Id != @1", Name,ID)
                                            .Take(1).ToListAsync();
             }
    
             if(subCategories.Count > 0)
             {
                return Json(true,JsonRequestBehavior.AllowGet);
             }
             return Json(false,JsonRequestBehavior.AllowGet);
         }
         else
         {
            throw new Exception("Table name does not exist with the provided name");
         }
    }
