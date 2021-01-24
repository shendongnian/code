    async Task Main()
    {
    	var result = await GetTest();	
    	result.Dump();
    }
    
    public async Task<IEnumerable<Test>> GetTest()
    {
    	var value = await GetTestDb();
    	return value.Where(x => x.Id == 1);
    }
    
    public async Task<IEnumerable<Test>> GetTestDb()
    {
    	return await Task.FromResult(
    	new List<Test>
    	{
    		new Test{Id = 1, Name = "M"},
    		new Test{Id = 2, Name = "S"}
    	}
    	);
    }
    
    public class Test
    {
    	public int Id { get; set; }
    
    	public string Name { get; set; }
    }
