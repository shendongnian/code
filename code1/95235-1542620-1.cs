    private static object s_Lock = new object();
    private static volatile MyObject s_MyObject;
    private static MyObject LoadMyObject()
    {
        MyObject myObject = new MyObject();
        myObject.Initialize();
        return myObject;
    }
    private static MyObject GetMyObject()
    {
        if (s_MyObject == null)
        {
            lock (s_Lock)
            {
                if (s_MyObject == null) // Check again now that we're in the lock.
                    s_MyObject = LoadMyObject(); // Only one access does this work.
            }
        }
        return s_MyObject; // Once it's set, it's never cleared or assigned again.
    }
This has the advantage of only doing the init work once, but also avoiding the lock contention overhead unless it's actually needed... while still being threadsafe.  (You could use volatile as above if you want to be sure it propagates out, but this should also "work" without it; it would just be more likley to need the lock before seeing the new contents of s_MyObject, depending on the architecture.  So I think volatile is helpful for this approach.)
I've kept your LoadMyObject and GetMyObject methods, but you could combine the logic into the inner if's then clause for a single factory method.
