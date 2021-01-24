    async Task Main()
    {
    	await stream();
    }
    
    // Define other methods and classes here
    public class FathersData
    {
    	public Father[] Fathers { get; set; }
    }
    
    public class Someone
    {
    	public string Name { get; set; }
    }
    
    public class Father : Someone
    {
    	public int Id { get; set; }
    	public bool Married { get; set; }
    	// Lists...
    	public List<Son> Sons { get; set; }
    	// ... or arrays for collections, that's fine:
    	public Daughter[] Daughters { get; set; }
    }
    
    public class Child : Someone
    {
    	public int age { get; set; }
    }
    
    public class Son : Child
    {
    }
    
    public class Daughter : Child
    {
    	public string maidenName { get; set; }
    }
    
    public async Task stream()
    {
        var fatherReader = new FatherReader();
    	fatherReader.FatherReaded += (s, f) => {
    		//f.name.Dump();
    		System.Diagnostics.Debug.WriteLine(f.Name);
    	};
    	string apiUrl = "https://raw.githubusercontent.com/ysharplanguage/FastJsonParser/master/JsonTest/TestData/fathers.json.txt";
    	
    	using (var client = new HttpClient())
    	using (var stream = await client.GetStreamAsync(apiUrl).ConfigureAwait(false))
    	{
    		fatherReader.Read(stream);
    	}
    }
    
    public class FatherReader
    {
    	public event System.EventHandler<Father> FatherReaded;
    	
    	public FatherReader()
    	{
    		
    	}
    	
    	private void OnFatherReaded(Father father){
    		FatherReaded?.Invoke(this, father);
    	}
    
    	public void Read(Stream stream)
    	{
    		using (var reader = new StreamReader(stream))
    		using (var jsonReader = new JsonTextReader(reader))
    		{
    			JsonSerializer serializer = new JsonSerializer();
    			
    			jsonReader.Read(); // Skip the first StartObject token
    			
    			while (jsonReader.Read())
    			{
    				if (jsonReader.TokenType == JsonToken.StartObject)
    				{
    					var father = serializer.Deserialize(jsonReader, typeof(Father));
    					OnFatherReaded((Father)father);
    				}
    			}
    		}
    	}
    }
