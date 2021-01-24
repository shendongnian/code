    class Program
    {
    	static List<Data> data = new List<Data>();
    	static List<Data> result = new List<Data>();
    
    	static void Main(string[] args)
    	{
    
    		data.Add(new Data() { Parent = null, ID = 1 });
    		data.Add(new Data() { Parent = 1, ID = 2 });
    		data.Add(new Data() { Parent = 2, ID = 3 });
    		data.Add(new Data() { Parent = 3, ID = 4 });
    		data.Add(new Data() { Parent = 4, ID = 5 });
    		data.Add(new Data() { Parent = null, ID = 6 });
    
            // Take() implementation is for Depth. 
    		result = findChildren(3).Take(2).ToList();
    
    		Console.ReadLine();
    	}
    
    	static List<Data> findChildren(int Id)
    	{
    		return data.Where(x => x.Parent == Id ).Union(data.Where(x => x.Parent == Id).SelectMany(y => findChildren(y.ID))).ToList();
    	}
    
    }
    
    public class Data
    {
    	public int? Parent { get; set; }
    	public int ID { get; set; }
    }
