    public FieldBase<T,TThis> 
    	where TThis : FieldBase<T,TThis>
    {
    	public TThis Name( string name ) 
    	{
    		_name = name;
    		return (TThis)this;
    	}
    }
    
    public Field<T> : FieldBase<T,Field<T>>{}
    
    public SpecialFieldBase<T,TThis> : FieldBase<T,TThis>
    	where TThis : SpecialFieldBase<T,TThis>
    {
    	public TThis Special(){ return (TThis)this; }
    }
    
    public SpecialField<T> : SpecialFieldBase<T,SpecialField<T>>{}
    
    
    // Yeah it works!
    var = specialField = new SpecialField()
    	.Name( "bing" )
    	.Special();
