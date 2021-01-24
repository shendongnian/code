    void Main()
    {
    	var list = new List<RandomData>();
    	
    	DoSomething(list);
    }
    
    public void DoSomething<T>(List<T> input) where T : IData
    {
    	foreach(var v in input)
      	{
    		byte[] data = v.Data;
    		string name = v.Name;
    	}
    }
    
    public interface IData
    {
    	byte[] Data { get; set; }
    	
    	string Name { get; set; }
    }
    
    class RandomData : IData
    {
    	public byte[] Data { get; set; }
    
    	public string Name { get; set; }
    }
