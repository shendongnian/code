    public class MyGenericClass<V>
      where V : Item  //This is a constraint that requires type V to be an Item (or subtype)
    {
      public void DoSomething()
      {
        List<V> myList = someMethod();
        
        foreach (V element in myList)
        {
          //This will now work because you've constrained the generic type V
          Guid test = element.IetmGuid;
        }
      }
    }
