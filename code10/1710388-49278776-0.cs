    public async Task<IEnumerable<T>> TestMethod(IEnumerable<MasterDataFileOperationItem> items)
    {
    
    	var ids = items.Select(i => i.Id).ToArray().Select(x => x.ToString()).ToArray();
    
    	var result = await _repository.GetAll().Where(x => ids.Contains(x.Id)).ToListAsync();
    
    	var returnVal = MapResults(result).ToList();
    
    	var temp = CreateTestEntity(testNos);
    
    	returnVal.AddRange(temp);
    
    	return returnVal;
    }
    public IEnumerable<T> CreateTestEntity(string[] testNos)
    {
    	List<TestEntity> ls = new List<TestEntity>();
    	foreach (var testNo in testNos)
    	{
    		var TestEntity = new TestEntity
    		{
    			TestNo = testNo,
    		};
    
    		ls.Add(TestEntity);
    	}
    
    	return (IEnumerable<T>) ls;
    }
