    [TestMethod]
    public void WorksWithAreaCategories()
    {
    	using (new TransactionScope())
    	{
    		//arrange
    		var context = ContextFactory.Create();
    		var categoryBusiness = new CategoryBusiness(context);
    		var category = new Category
    						{
    							Name = "TestCategory###"
    						};
    		categoryBusiness.Add(category);
    
    		var areaBusiness = new AreaBusiness(context);
    		var area = new Area
    						{
    							Name = "TestArea###",
    							Description = "TestAreaDescription###",
    						};
    		areaBusiness.Add(area);
    		
    		//act
    		area.Categories = new List<Category> { category };
    		areaBusiness.Update(area);
    
    		//assert
    		var areaFromDb = areaBusiness.FindById(area.AreaID);
    		Assert.IsNotNull(areaFromDb.Categories);
    		Assert.IsTrue(areaFromDb.Categories.Count > 0);
    		Assert.IsTrue(areaFromDb.Categories.Any(c => c.CategoryID == category.CategoryID));
    	}
    }
