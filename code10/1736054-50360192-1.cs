    // A object can have to kinds of properties, simple values or sub-objects
    public enum GraphElementType {
    	@Object,	
    	Value
    }
    
    // To make it easy to keep all values and objects in order, we define a single base class for both
    // We define all elements to have a name, and set a static name for the root element
    public abstract class GraphElement
    {
    	public static readonly string ROOT_NAME = "<ROOT>";
    	
    	public GraphElementType ElementType { get; }
    	public string Name {get;}
    	
    	protected GraphElement(GraphElementType type, string name) {
    		ElementType = type;
    		Name = name;
    	}
    }
    
    public class GraphValue : GraphElement
    {
    	public GraphValue(string name) : base(GraphElementType.Value, name) { }
    }
    
    public class GraphObject : GraphElement {	
    	public List<GraphElement> Properties {get;} = new List<GraphElement>();
    
    	public GraphObject(string name) : base(GraphElementType.Object, name) { }
    	
    	
    	public static GraphObject Read(string graphString)
    	{
    		return Read(new StringReader(graphString));
    	}
    	
    	public static GraphObject Read(TextReader reader)
	    {
		    var root = Read(GraphElement.ROOT_NAME, reader);		
		    if(ConsumeWhitespaceAndPeek(reader) != -1) {
			    throw new ApplicationException("Unexpected content after root object");
		    }		
		    return root;
	    }
        
    	// Read an object with the given name from the given reader.
    	// The reader must be positioned at the opening brace of the object.
    	protected static GraphObject Read(string name, TextReader reader)
    	{
    		// Consume opening '{'
    		if (reader.Read() != '{') throw new ApplicationException("Invalid object start");
    		
    		var o = new GraphObject(name); 		
    		while(true)
    		{
    			var next = ConsumeWhitespaceAndPeek(reader);
    			if (next == -1) throw new ApplicationException("Unexpected end of input, unclosed object");
    			
    			if (next == '}')  {
    				reader.Read(); // consume closing '}'
    				return o;
    			}
    
    			var str = ConsumeUntilWhitespaceOrBrace(reader);
    			next = ConsumeWhitespaceAndPeek(reader);		 
    
    			if (str.Length > 0 && next  == '{')
    			{
    				o.Properties.Add(Read(str, reader));
    			}
    			else if (str.Length > 0)
    			{
    				o.Properties.Add(new GraphValue(str));
    			}
    		}
    	}
    	// Helper method: Collect all non-whitespace, non-brace characters into a string
    	private static string ConsumeUntilWhitespaceOrBrace(TextReader reader) {
    		var b = new StringBuilder();
    
    		var next = reader.Peek();
    		while (next != -1 && !Char.IsWhiteSpace((char)next) && next != '}' && next != '{') {
    			b.Append((char)next);
    			reader.Read();
    			next = reader.Peek();
    		}
    		
    		return b.ToString();
    	}
    	
    	// Helper method: Advance reader past any whitespace
    	private static int ConsumeWhitespaceAndPeek(TextReader reader) {
    		var next = reader.Peek();
    		while(next != -1 && Char.IsWhiteSpace((char)next)) {
    			reader.Read();
    			next = reader.Peek();
    		}
    		
    		return next;
    	}
    }
