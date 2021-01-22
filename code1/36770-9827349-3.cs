    public static void IsGarbageCollected<TObject>( ref TObject @object )
    	where TObject : class
    {
    	Action<TObject> emptyAction = o => { };
    	IsGarbageCollected( ref @object, emptyAction );
    }
    
    public static void IsGarbageCollected<TObject>(
        ref TObject @object,
        Action<TObject> useObject )
    	where TObject : class
    {
        if ( typeof( TObject ) == typeof( string ) )
        {
    	    // Strings are copied by value, and don't leak anyhow.
    	    return;
        }
    	int generation = GC.GetGeneration( @object );
    	useObject( @object );
    	WeakReference reference = new WeakReference( @object, true );
    	@object = null;
    
    	// The object should have gone out of scope about now, 
    	// so the garbage collector can clean it up.
    	GC.Collect( generation, GCCollectionMode.Forced );
    	GC.WaitForPendingFinalizers();
    
    	Assert.IsNull( reference.Target );
    }
