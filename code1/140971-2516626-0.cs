    public IEnumerable<MyObject> GetObjects()
    {
         foreach (MyObject foo in GetObjectsFromSomewhereElse())
         {
             MyObject bar = DoSomeProcessing(foo);
             yield return bar;
         }
    }
