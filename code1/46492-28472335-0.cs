    public abstract class CustomEnum
    {
    	private readonly string _name;
    	private readonly object _id;
    
    	protected CustomEnum( string name, object id )
    	{
    		_name = name;
    		_id = id;
    	}
    
    	public string Name
    	{
    		get { return _name; }
    	}
    
    	public object Id
    	{
    		get { return _id; }
    	}
    
    	public override string ToString()
    	{
    		return _name;
    	}
    }
    
    public abstract class CustomEnum<TEnumType, TIdType> : CustomEnum
    	where TEnumType : CustomEnum<TEnumType, TIdType>
    {
    	protected CustomEnum( string name, TIdType id )
    		: base( name, id )
    	{ }
    
    	public new TIdType Id
    	{
    		get { return (TIdType)base.Id; }
    	}
    
    	public static TEnumType FromName( string name )
    	{
    		try
    		{
    			return FromDelegate( entry => entry.Name.Equals( name ) );
    		}
    		catch (ArgumentException ae)
    		{
    			throw new ArgumentException( "Illegal name for custom enum '" + typeof( TEnumType ).Name + "'", ae );
    		}
    	}
    
    	public static TEnumType FromId( TIdType id )
    	{
    		try
    		{
    			return FromDelegate( entry => entry.Id.Equals( id ) );
    		}
    		catch (ArgumentException ae)
    		{
    			throw new ArgumentException( "Illegal id for custom enum '" + typeof( TEnumType ).Name + "'", ae );
    		}
    	}
    
    	public static IEnumerable<TEnumType> GetAll()
    	{
    		var elements = new Collection<TEnumType>();
    		var infoArray = typeof( TEnumType ).GetFields( BindingFlags.Public | BindingFlags.Static );
    
    		foreach (var info in infoArray)
    		{
    			var type = info.GetValue( null ) as TEnumType;
    			elements.Add( type );
    		}
    
    		return elements;
    	}
    
    	protected static TEnumType FromDelegate( Predicate<TEnumType> predicate )
    	{
    		if(predicate == null)
    			throw new ArgumentNullException( "predicate" );
    
    		foreach (var entry in GetAll())
    		{
    			if (predicate( entry ))
    				return entry;
    		}
    
    		throw new ArgumentException( "Element not found while using predicate" );
    	}
    }
