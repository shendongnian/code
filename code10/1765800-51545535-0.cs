    void Main()
    {
    	Stockholder stockholder = new Stockholder
    	{
    		FullName = "Steve Stockholder",
    		Businesses = new List<Business>
    		{
    			new Hotel
    			{
    				Name = "Hudson Hotel",
    				Stars = 4
    			}
    		}
    		
    	};
    
    	var settings = new JsonSerializerSettings
    	{
    		TypeNameHandling = TypeNameHandling.Objects,
    		SerializationBinder = new KnownTypesBinder { KnownTypes = new List<Type> { typeof(Stockholder), typeof(Hotel) }}
    	};
    	
    	string ok;
    
    	/*
    	ok = JsonConvert.SerializeObject(stockholder, Newtonsoft.Json.Formatting.Indented, settings);
    	
    	Console.WriteLine(ok);*/
    
    	ok = @"{
      ""$type"": ""Stockholder"",
      ""FullName"": ""Steve Stockholder"",
      ""Businesses"": [
        {
          ""$type"": ""Hotel"",
          ""Stars"": 4,
          ""Name"": ""Hudson Hotel""
        }
      ]
    }";
    
    	JsonConvert.DeserializeObject<Stockholder>(ok, settings).Dump();
    	
    	var vector = @"{
      ""$type"": ""Stockholder"",
      ""FullName"": ""Steve Stockholder"",
      ""Businesses"": [
        {
          ""$type"": ""System.IO.FileInfo, System.IO.FileSystem"",
    	  ""fileName"": ""d:\rce-test.txt"",
    	  ""IsReadOnly"": true
        }
      ]
    }";
    
    	JsonConvert.DeserializeObject<Stockholder>(vector, settings).Dump(); // will fail
    }
    
    public class KnownTypesBinder : ISerializationBinder
    {
    	public IList<Type> KnownTypes { get; set; }
    
    	public Type BindToType(string assemblyName, string typeName)
    	{
    		return KnownTypes.SingleOrDefault(t => t.Name == typeName);
    	}
    
    	public void BindToName(Type serializedType, out string assemblyName, out string typeName)
    	{
    		assemblyName = null;
    		typeName = serializedType.Name;
    	}
    }
    
    public abstract class Business
    {
    	public string Name { get; set; }
    }
    
    public class Hotel: Business
    {
    	public int Stars { get; set; }
    }
    
    public class Stockholder
    {
    	public string FullName { get; set; }
    	public IList<Business> Businesses { get; set; }
    }
