    public class PacketReader : StringReader
    {
    	public PacketReader(string s)
    		: base(s)
    	{
    	}
    
    	public T ReadNext<T>() where T : IConvertible
    	{
    		var sb = new StringBuilder();
    
    		do
    		{
    			var current = Read();
    			if (current < 0)
    				break;
    
    			sb.Append((char)current);
    
    			var next = (char)Peek();
    			if (char.IsWhiteSpace(next))
    				break;
    
    		} while (true);
    
    		var value = sb.ToString();
    
    		var type = typeof(T);
    		if (type.IsEnum)
    			return (T)Enum.Parse(type, value);
    
    		return (T)((IConvertible)value).ToType(typeof(T), System.Globalization.CultureInfo.CurrentCulture);
    	}
    
    }
