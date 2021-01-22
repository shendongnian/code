    public class ParentClass
    {
      private static Func<FriendClass> _friendContract;
    
      public class FriendClass
      {
          static FriendClass()
          {
              _friendContract= () => new FriendClass();
          }
          private FriendClass() { }
      }
      ///Usage
      public FriendClass MethodUse()
      {
          var fInstance = _friendContract();
          //fInstance.DoSomething();
          return fInstance;
      }
    }
