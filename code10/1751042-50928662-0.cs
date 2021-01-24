    void Main()
    {
    	DBModel t = new DBModel() { Description = "Google", Link = "http://www.google.com"};
    	TestViewModel k = t;
    	Console.WriteLine(k.Description);
    	Console.WriteLine(k.Link);
    }
    
    public class TestViewModel
    {
        public string Description { get; set; }
    	public string Link { get; set; }
    
    	public static implicit operator TestViewModel(DBModel source)
    	{
    		if (source == null) return null;
    		TestViewModel model = new TestViewModel()
    		{
    			Description = source.Description,
    			Link = source.Link
    		};
    		return model;
    	}
    }
    
    public class DBModel
    {
    	public string Description { get; set; }
    	public string Link { get; set; }
    }
