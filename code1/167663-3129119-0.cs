    bool synchronized = true;
    var collection = new MyCustomCollection(synchronized);
    var results = collection.DoSomething();
    
    public class MyCustomCollection 
    {
      public readonly bool IsSynchronized;
      public MyCustomCollection(bool synchronized)
      {
       IsSynchronized = synchronized
      }
    
      public ICollection DoSomething()
      { 
        //am wondering if there is a better way to do it without using if/else
        if(IsSynchronized)
        {
         lock(SyncRoot)
         {
           MyPrivateMethodToDoSomething();
         }
        }
        else
        {
          MyPrivateMethodToDoSomething();
        }
    
      }
    }
