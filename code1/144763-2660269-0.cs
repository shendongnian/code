    void Main()
    {
    	var js = new JavaScriptSerializer();
    	js.RegisterConverters(new[]	{ new PonySerializer() });
    	var pony = js.Deserialize<Pony>(@"{""Foo"":""null""}");
    	pony.Dump();
    }
    
    public class PonySerializer : JavaScriptConverter
    {
    	public override IEnumerable<Type> SupportedTypes
    	{
    		get { return new [] { typeof(Pony) }; }
    	}
    	
    	public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
    	{
    		throw new NotImplementedException();
    	}
    	
    	public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
    	{
    		if (dictionary == null)
    			throw new ArgumentNullException("dictionary");
    			
    		if (type == typeof(Pony))
    		{
    			var pony = new Pony();
    			int intValue;
    			
    			if (!int.TryParse(dictionary["Foo"] as string, out intValue))
    				intValue = -1; // default value. You can throw an exception or log it or do whatever you want here
    			
    			pony.Foo = intValue;
    			return pony;
    		}
    		return null;
    	}
    }
    
    public class Pony
    {
    	public int Foo { get; set; }
    }
