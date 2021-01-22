    public class BijectiveDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
    	public BijectiveDictionary<TValue, TKey> Reversed { get; protected set; }
    
    	public BijectiveDictionary()
    	{
    		this.Reversed = new BijectiveDictionary<TValue,TKey>(true);
    		this.Reversed.Reversed = this;
    	}
    
    	protected BijectiveDictionary(bool reversedWillBeSetFromTheCallingBiji) { }
    
    	protected void AddRaw(TKey key, TValue value)
    	{
    		base.Add(key, value);
    	}
    
    	// Just for demonstration - you should implement the IDictionary interface instead.
    	public new void Add(TKey key, TValue value)
    	{
    		base.Add(key, value);
    		this.Reversed.AddRaw(value, key);
    	}
    
    	public static explicit operator BijectiveDictionary<TValue, TKey>(BijectiveDictionary<TKey, TValue> biji)
    	{
    		return biji.Reversed;
    	}
    }
