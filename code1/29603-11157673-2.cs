    public abstract class Enumeration<T>
        where T : Enumeration<T>
    {	
    	protected static int nextOrdinal = 0;
    	
    	protected static readonly Dictionary<int, Enumeration<T>> byOrdinal = new Dictionary<int, Enumeration<T>>();
    	protected static readonly Dictionary<string, Enumeration<T>> byName = new Dictionary<string, Enumeration<T>>();
    	
    	protected readonly string name;
    	protected readonly int ordinal;
    	
    	protected Enumeration(string name)
    		: this (name, nextOrdinal)
    	{
    	}
    	
    	protected Enumeration(string name, int ordinal)
    	{
    		this.name = name;
    		this.ordinal = ordinal;
    		nextOrdinal = ordinal + 1;
    		byOrdinal.Add(ordinal, this);
    		byName.Add(name, this);
    	}
    	
    	public override string ToString()
    	{
    		return name;
    	}
    	
    	public string Name 
    	{
    		get { return name; }
    	}
    	
    	public static explicit operator int(Enumeration<T> obj)
    	{
    		return obj.ordinal;
    	}
    	
    	public int Ordinal
    	{
    		get { return ordinal; }
    	}
    }
