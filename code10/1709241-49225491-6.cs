    [TestInitialize]
    public void TestInitialize()
    {
    	_client = new ApiClient();
    	var context = TestDataConfiguration.GetContex();
    	var category = new Category
    	{
    		Active = true,
    		Description = "D",
    		Name = "N"
    	};
    	context.Categories.Add(category);
    	context.SaveChanges();
    	var transaction = new Transaction
    	{
    		CategoryId = category.Id,
    		Credit = 1,
    		Description = "A",
    		Recorded = DateTime.Now
    	};
    	context.Transactions.Add(transaction);
    	context.SaveChanges();
    }
