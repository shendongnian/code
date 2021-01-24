    public class Example : IDeserializable<Example>
    {
    	//...
    
    	public Example FromJson(JsonReader reader)
    	{
    		// populate the object with json...
            // you can create complex object like this:
            // this.Example2 = new Example2().FromJson(reader);
    
    		return this;
    	}
    }
