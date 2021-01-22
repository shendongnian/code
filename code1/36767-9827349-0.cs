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
