    // Example 1 - In a using statement, so the object gets freed at the end.
    using (PooledObject<Foo> pooledObject = SharedPools.Default<List<Foo>>().GetPooledObject())
    {
        // Do something with pooledObject.Object
    }
    
    // Example 2 - No using statement so you need to be sure no exceptions are not thrown.
    List<Foo> list = SharedPools.Default<List<Foo>>().AllocateAndClear();
    // Do something with list
    SharedPools.Default<List<Foo>>().Free(list);
    
    // Example 3 - I have also seen this variation of the above pattern, which ends up the same as Example 1, except Example 1 seems to create a new instance of the IDisposable [PooledObject<T>][4] object. This is probably the preferred option if you want fewer GC's.
    List<Foo> list = SharedPools.Default<List<Foo>>().AllocateAndClear();
    try
    {
        // Do something with list
    }
    finally
    {
        SharedPools.Default<List<Foo>>().Free(list);
    }
