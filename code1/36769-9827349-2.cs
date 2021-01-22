    [TestMethod]
    public void IsGarbageCollectedTest()
    {
    	// Empty object without any references which are held.
    	object empty = new object();
    	AssertHelper.IsGarbageCollected( ref empty );
    
    	// Strings are copied by value, but are collectable!
    	string @string = "";
    	AssertHelper.IsGarbageCollected( ref @string );
    
    	// Keep reference around.
    	object hookedEvent = new object();
    	#pragma warning disable 168
    	object referenceCopy = hookedEvent;
    	#pragma warning restore 168
    	AssertHelper.ThrowsException<AssertFailedException>(
            () => AssertHelper.IsGarbageCollected( ref hookedEvent ) );
    
    	// Still attached as event.
    	Publisher publisher = new Publisher();
    	Subscriber subscriber = new Subscriber( publisher );
    	AssertHelper.ThrowsException<AssertFailedException>(
            () => AssertHelper.IsGarbageCollected( ref subscriber ) );
    }
