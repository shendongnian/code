    public JsonResult IsSubCategoryExist(string Name, int? ID, string ClassName)
    {
          var type = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(t => t.Name == ClassName);
    
          if (type != null)
          {
             DbSet dbSet = _dbContext.Set(type);
             var subCategory = dbSet.Where("Name = @0 and Id = @1", Name, ID); // Specify your condition dynamically here
    
             if(subCategory != null)
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
