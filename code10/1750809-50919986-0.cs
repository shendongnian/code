    class Program
    {
    	static void Main(string[] args)
    	{
    		List<Data> data = new List<Data>();
    		data.Add(new Data() { Id = 1, Name = "Dep 1", ParentId = 0, Level = 0 });
    		data.Add(new Data() { Name = "Dep 2", ParentId = 1, Id = 2, Level = 1 });
    		data.Add(new Data() { Name = "Dep 6", ParentId = 2, Id = 6, Level = 2 });
    		data.Add(new Data() { Name = "Dep 4", ParentId = 1, Id = 4, Level = 1 });
    		data.Add(new Data() { Name = "Dep 5", ParentId = 4, Id = 5, Level = 2 });
    		data.Add(new Data() { Name = "Dep 3", ParentId = 0, Id = 3, Level = 0 });
    
    		var result = data
    					.Where(c=>c.Level == 0)
    					.Select(c => new Result
    					{
    						Id = c.Id,
    						Name = c.Name,
    						Children = GetChildren(data, c.Id)
    					}).ToList();
    
    		string resultJson = JsonConvert.SerializeObject(result);
    
    		Console.ReadLine();
    	}
    
    	public static List<Result> GetChildren(List<Data> records, int parentId)
    	{
    		return records
    				.Where(c => c.ParentId == parentId)
    				.Select(c => new Result
    				{
    					Id = c.Id,
    					Name = c.Name,
    					Children = GetChildren(records, c.Id)
    				}).ToList();
    	}
    }
    
    public class Data
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public int ParentId { get; set; }
    	public int Level { get; set; }
    }
    
    public class Result
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public List<Result> Children { get; set; }
    }
