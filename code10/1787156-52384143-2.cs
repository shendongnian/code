    public async Task stream()
    {
    	var fatherReader = new FatherReader();
    	var observable = fatherReader.Observable;
    
        // Here you can chain many operator like Linq (filtre, transforme, ...)
    	observable = observable
    		.Where(f => f.Name.StartsWith("J"));
    
    	observable.Subscribe(f => f.Name.Dump(), e => e.ToString().Dump());
    
    	string apiUrl = "https://raw.githubusercontent.com/ysharplanguage/FastJsonParser/master/JsonTest/TestData/fathers.json.txt";
    
    	using (var client = new HttpClient())
    	using (var stream = await client.GetStreamAsync(apiUrl).ConfigureAwait(false))
    	{
    		fatherReader.Read(stream);
    	}
    }
    
    public class FatherReader
    {
    	private Subject<Father> _observable = new Subject<Father>();
    	public IObservable<Father> Observable => _observable.AsObservable();
    
    	public FatherReader()
    	{
    	}
    
    	private void OnFatherReaded(Father father)
    	{
    		_observable.OnNext(father);
    	}
    
    	public void Read(Stream stream)
    	{
    		try
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
    						try
    						{
    							var father = serializer.Deserialize(jsonReader, typeof(Father));
    							OnFatherReaded((Father)father);
    						}
    						catch (Exception ex)
    						{
    							_observable.OnError(ex);
    						}
    					}
    				}
    			}
    		}
    		catch (Exception ex)
    		{
    			_observable.OnError(ex);
    		}
    
    		_observable.OnCompleted();
    	}
    }
