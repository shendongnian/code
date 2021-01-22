    public class FieldBase<T,TThis> 
    	where TThis : FieldBase<T,TThis>
    {
        private string _name;
    	public TThis Name( string name ) 
    	{
    		_name = name;
    		return (TThis)this;
    	}
    }
    
    public class Field<T> : FieldBase<T,Field<T>>{}
    
    public class SpecialFieldBase<T,TThis> : FieldBase<T,TThis>
    	where TThis : SpecialFieldBase<T,TThis>
    {
    	public TThis Special(){ return (TThis)this; }
    }
    
    public class SpecialField<T> : SpecialFieldBase<T,SpecialField<T>>{}
    
    
    // Yeah it works!
    var specialField = new SpecialField<string>()
    	.Name( "bing" )
    	.Special();
