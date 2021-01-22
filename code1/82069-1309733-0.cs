    void Main()
    {
    	int? x = null;
    	var wrap = new NullableWrapper<int>( x );
    	
    	wrap.HasBeenSet.Dump();  // false
    	wrap.HasValue.Dump();   // false
    	
    	wrap = 10;
    	
    	wrap.HasBeenSet.Dump();  // true
    	wrap.HasValue.Dump();    // true
    	wrap.Value.Dump();       // 10
    	
    	int? y = wrap;
    	
    	y.HasValue.Dump();   // True
    	y.Value.Dump();      // 10
        wrap = null;
        wrap.HasBeenSet.Dump();  // Does now work like expected => bad
    }
    
    public class NullableWrapper<T> where T : struct
    {
      private Nullable<T> _impl;
      private bool _hasBeenSet = false;
      
      public NullableWrapper( Nullable<T> t )
      {
        _impl = t;
        _hasBeenSet = t.HasValue;
      }
     
      public bool HasBeenSet
      {
        get { return _hasBeenSet; }
      }
      
      public bool HasValue
      {
        get { return _impl.HasValue; }
      }
      
      public T Value
      {
        get { return _impl.Value; }
    	set { _impl = value; _hasBeenSet = true; }
      }
      
      public void Clear()
      {
        _hasBeenSet = false;
      }
      
      public static implicit operator Nullable<T>( NullableWrapper<T> lhs )
      {
        return lhs._impl;
      }
      
      public static implicit operator NullableWrapper<T>( T rhs )
      {
        return( new NullableWrapper<T>( rhs ) );
      }
    }
